using Datos;
using Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using MimeKit;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Logica
{
    public class L_Usuarios
    {
        private readonly D_Usuarios DUsuario = new D_Usuarios();

        private string ObtenerConfigCorreo(string clave)
        {
            string ruta = System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");

            string json = System.IO.File.ReadAllText(ruta);

            var obj = Newtonsoft.Json.Linq.JObject.Parse(json);
            return obj["MailSettings"][clave].ToString();
        }

        public async Task<Solicitud> IniciarSesion(string usuario, string contraseña)
        {
            try
            {
                if (usuario == null)
                    return new Solicitud
                    {
                        Estado = false,
                        Mensaje = "Datos de usuario no proporcionados."
                    };

                if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contraseña))
                    return new Solicitud
                    {
                        Estado = false,
                        Mensaje = "El usuario y la contraseña son obligatorios."
                    };

                string hashContraseña = EncriptarConSHA256(contraseña);

                Usuarios esValido = await DUsuario.IniciarSesion(usuario, hashContraseña);

                if (esValido != null && !esValido.User.Equals(usuario, StringComparison.Ordinal))
                {
                    return new Solicitud
                    {
                        Estado = false,
                        Mensaje = "Usuario o contraseña incorrectos."
                    };
                }

                if (esValido != null && !esValido.PermitirIngreso)
                {
                    return new Solicitud
                    {
                        Estado = false,
                        Mensaje = "Tu acceso ha sido bloqueado por el administrador."
                    };
                }

                if (esValido != null)
                    return new Solicitud
                    {
                        Estado = true,
                        Mensaje = "Credenciales Válidas",
                        Datos = esValido
                    };

                return new Solicitud
                {
                    Estado = false,
                    Mensaje = "Usuario o contraseña incorrectos.",
                    Datos = null
                };
            }
            catch (Exception)
            {
                return new Solicitud
                {
                    Estado = false,
                    Mensaje = "Ocurrió un error interno en el servidor."
                };
            }
        }

        public async Task<Solicitud> CambiarContraseña(string passActual, string passNueva, string confirmarPass)
        {
            if (
                string.IsNullOrWhiteSpace(passActual) ||
                string.IsNullOrWhiteSpace(passNueva) ||
                string.IsNullOrWhiteSpace(confirmarPass)
                )
            {
                return new Solicitud
                {
                    Estado = false,
                    Mensaje = "Todos los campos son obligatorios."
                };
            }

            if (passNueva != confirmarPass)
                return new Solicitud
                {
                    Estado = false,
                    Mensaje = "Las nuevas contraseñas no coinciden."
                };

            int idUsuario = Entidades.SesionUsuario.UsuarioLogueado.Id;

            string hashActual = EncriptarConSHA256(passActual);
            string hashNueva = EncriptarConSHA256(passNueva);

            D_Usuarios datos = new D_Usuarios();

            if (!await datos.VerificarContraseña(hashActual, idUsuario))
                return new Solicitud
                {
                    Estado = false,
                    Mensaje = "La contraseña actual es incorrecta."
                };

            bool exito = await datos.ActualizarContraseña(hashNueva, idUsuario);

            return new Solicitud
            {
                Estado = exito,
                Mensaje = exito ? "Contraseña actualizada exitosamente." : "Error crítico al guardar."
            };
        }

        public async Task<Usuarios> ObtenerInformacionUsuarioUnico()
        {
            return await DUsuario.ObtenerUsuarioUnico();
        }

        public async Task<Solicitud> SolicitarRecuperacion(string email)
        {
            try
            {
                int? idUsuario = await DUsuario.ObtenerIdPorEmail(email);

                if (idUsuario is null)
                {
                    return new Solicitud
                    {
                        Estado = false,
                        Mensaje = "El correo no esta registrado."
                    };
                }

                byte[] unico = new byte[32];
                using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
                {
                    rng.GetBytes(unico);
                }

                string token = BitConverter.ToString(unico).Replace("-", "");

                string encriptado = EncriptarConSHA256(token);

                DateTime expiracion = DateTime.Now.AddMinutes(20);

                await DUsuario.InsertarTokenRecuperacion(idUsuario.Value, encriptado, expiracion);

                var envio = await EnviarCorreoRecuperacion(email, token);

                return envio;
            }
            catch (Exception ex)
            {
                return new Solicitud
                {
                    Estado = false,
                    Mensaje = ex.Message
                };
            }
        }

        private string EncriptarConSHA256(string textoPlano)
        {
            byte[] tokenBytes = Encoding.UTF8.GetBytes(textoPlano);
            byte[] hashBytes;

            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                hashBytes = sha256.ComputeHash(tokenBytes);
            }

            return BitConverter.ToString(hashBytes).Replace("-", "");
        }

        public async Task<Solicitud> RestablecerContraseña(string nuevaContraseña, string tokenPlano)
        {
            try
            {
                string tokenEncriptado = EncriptarConSHA256(tokenPlano);

                int? IdUsuario = await DUsuario.ValidarToken(tokenEncriptado);

                if (IdUsuario is null)
                {
                    return new Solicitud
                    {
                        Estado = false,
                        Mensaje = "Token inválido o expirado."
                    };
                }

                string nuevaContraseñaEncriptada = EncriptarConSHA256(nuevaContraseña);

                int resultado = await DUsuario.RestablecerContraseña(IdUsuario.Value, nuevaContraseñaEncriptada, tokenEncriptado);

                return new Solicitud
                {
                    Estado = resultado > 0,
                    Mensaje = resultado > 0 ? "Contraseña restablecida exitosamente." : "No se pudo restablecer la contraseña."
                };
            }
            catch (Exception ex)
            {
                return new Solicitud
                {
                    Estado = false,
                    Mensaje = ex.Message
                };
            }
        }

        public async Task<Solicitud> ValidarTokenRecuperacion(string tokenPlano)
        {
            try
            {
                string encriptarTokenPlano = EncriptarConSHA256(tokenPlano);

                int? IdUsuario = await DUsuario.ValidarToken(encriptarTokenPlano);

                return IdUsuario is null ? new Solicitud
                {
                    Estado = false,
                    Mensaje = "Token inválido o expirado."
                } : new Solicitud
                {
                    Estado = true,
                    Mensaje = "Token válido.",
                    Datos = IdUsuario.Value
                };
            }
            catch (Exception ex)
            {
                return new Solicitud
                {
                    Estado = false,
                    Mensaje = ex.Message
                };
            }
        }

        private async Task<Solicitud> EnviarCorreoRecuperacion(string emailDestino, string tokenPlano)
        {
            try
            {
                string host = ObtenerConfigCorreo("Host");
                int puerto = Convert.ToInt32(ObtenerConfigCorreo("Port"));
                string from = ObtenerConfigCorreo("From");
                string user = ObtenerConfigCorreo("User");
                string pass = ObtenerConfigCorreo("Pass");

                MimeMessage mimeMessage = new MimeMessage();

                mimeMessage.From.Add(new MailboxAddress("CrediTrack", from));
                mimeMessage.To.Add(new MailboxAddress("", emailDestino));
                mimeMessage.Subject = "Recuperación de Contraseña - CrediTrack";
                mimeMessage.Body = new TextPart("plain")
                {
                    Text = $"Hola,\n\nRecibimos una solicitud para restablecer tu contraseña. Utiliza el siguiente token para continuar con el proceso de recuperación:\n\nToken: {tokenPlano}\n\nSi no solicitaste este cambio, por favor ignora este correo.\n\nSaludos,\nEquipo de CrediTrack"
                };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    await client.ConnectAsync(host, puerto, MailKit.Security.SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(user, pass);
                    await client.SendAsync(mimeMessage);
                    await client.DisconnectAsync(true);
                }

                return new Solicitud
                {
                    Estado = true,
                    Mensaje = "Correo de recuperación enviado exitosamente."
                };

            }
            catch (Exception ex)
            {
                return new Solicitud
                {
                    Estado = false,
                    Mensaje = ex.Message
                };
            }
        }

        public async Task<Solicitud> SolicitarRecuperacionUsuario(string email)
        {
            try
            {
                int? idUsuario = await DUsuario.ObtenerIdPorEmail(email);

                if (idUsuario is null)
                    return new Solicitud
                    {
                        Estado = false,
                        Mensaje = "El correo no está registrado."
                    };

                byte[] unico = new byte[32];
                using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
                    rng.GetBytes(unico);

                string token = BitConverter.ToString(unico).Replace("-", "");
                string encriptado = EncriptarConSHA256(token);
                DateTime expiracion = DateTime.Now.AddMinutes(20);

                await DUsuario.InsertarTokenRecuperacion(idUsuario.Value, encriptado, expiracion);

                return await EnviarCorreoRecuperacionUsuario(email, token);
            }
            catch (Exception ex)
            {
                return new Solicitud
                {
                    Estado = false,
                    Mensaje = ex.Message
                };
            }
        }

        public async Task<Solicitud> RestablecerUsuario(string nuevoUsuario, string confirmarUsuario, string tokenPlano)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nuevoUsuario) || string.IsNullOrWhiteSpace(confirmarUsuario))
                    return new Solicitud
                    {
                        Estado = false,
                        Mensaje = "Todos los campos son obligatorios."
                    };

                if (nuevoUsuario != confirmarUsuario)
                    return new Solicitud
                    {
                        Estado = false,
                        Mensaje = "Los usuarios ingresados no coinciden."
                    };

                string tokenEncriptado = EncriptarConSHA256(tokenPlano);
                int? idUsuario = await DUsuario.ValidarToken(tokenEncriptado);

                if (idUsuario is null)
                    return new Solicitud 
                    { 
                        Estado = false, 
                        Mensaje = "Token inválido o expirado." 
                    };

                int resultado = await DUsuario.RestablecerUsuario(idUsuario.Value, nuevoUsuario, tokenEncriptado);

                return new Solicitud
                {
                    Estado = resultado > 0,
                    Mensaje = resultado > 0 ? "Usuario restablecido exitosamente."
                                            : "No se pudo restablecer el usuario."
                };
            }
            catch (Exception ex)
            {
                return new Solicitud { Estado = false, Mensaje = ex.Message };
            }
        }

        private async Task<Solicitud> EnviarCorreoRecuperacionUsuario(string emailDestino, string tokenPlano)
        {
            try
            {
                string host = ObtenerConfigCorreo("Host");
                int puerto = Convert.ToInt32(ObtenerConfigCorreo("Port"));
                string from = ObtenerConfigCorreo("From");
                string user = ObtenerConfigCorreo("User");
                string pass = ObtenerConfigCorreo("Pass");

                MimeMessage msg = new MimeMessage();
                msg.From.Add(new MailboxAddress("CrediTrack", from));
                msg.To.Add(new MailboxAddress("", emailDestino));
                msg.Subject = "Recuperación de Usuario - CrediTrack";
                msg.Body = new TextPart("plain")
                {
                    Text = $"Hola,\n\nRecibimos una solicitud para restablecer tu usuario.\n\nToken: {tokenPlano}\n\nSi no solicitaste este cambio, ignora este correo.\n\nSaludos,\nEquipo de CrediTrack"
                };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    await client.ConnectAsync(host, puerto, MailKit.Security.SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(user, pass);
                    await client.SendAsync(msg);
                    await client.DisconnectAsync(true);
                }

                return new Solicitud
                {
                    Estado = true,
                    Mensaje = "Correo de recuperación enviado exitosamente."
                };
            }
            catch (Exception ex)
            {
                return new Solicitud
                {
                    Estado = false,
                    Mensaje = ex.Message
                };
            }
        }

        public async Task<Solicitud> ActualizarInformacionUsuario(Usuarios usuario)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(usuario.Nombre) ||
                    string.IsNullOrWhiteSpace(usuario.Apellido) ||
                    string.IsNullOrWhiteSpace(usuario.Cedula) ||
                    string.IsNullOrWhiteSpace(usuario.Correo))

                    return new Solicitud
                    {
                        Estado = false,
                        Mensaje = "Los campos obligatorios no pueden estar vacíos."
                    };

                bool exito = await DUsuario.ActualizarUsuario(usuario);
                return new Solicitud
                {
                    Estado = exito,
                    Mensaje = exito ? "Información actualizada exitosamente." : "No se pudo actualizar la información."
                };
            }
            catch (Exception ex)
            {
                return new Solicitud
                {
                    Estado = false,
                    Mensaje = ex.Message
                };
            }
        }
    }
}