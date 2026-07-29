using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Logica;
using Presentacion.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using PdfRect = iTextSharp.text.Rectangle;

namespace Presentacion.Presenter
{
    public class InformesPresenter
    {
        private readonly IInformesView _view;
        private readonly L_Creditos _logicaCreditos = new L_Creditos();
        private readonly L_Pagos _logicaPagos = new L_Pagos();
        private readonly L_Inventario _logicaInventario = new L_Inventario();

        public InformesPresenter(IInformesView view)
        {
            _view = view;
            _view.ReporteElegido += ReporteElegido_Accion;
            _view.ExportarPDF += ExportarPDF_Accion;
            _view.ExportarExcel += ExportarExcel_Accion;
            EvaluarFiltros();
        }

        private void ReporteElegido_Accion(object sender, EventArgs e)
        {
            EvaluarFiltros();
        }

        private void EvaluarFiltros()
        {
            _view.SelectorClienteHabilitado =
                _view.ReporteSeleccionado == "Estado de Cuenta Individual";
        }

        private async System.Threading.Tasks.Task<(DataTable datos, string titulo)> ObtenerDatos()
        {
            DateTime desde = _view.FechaDesde.Date;
            DateTime hasta = _view.FechaHasta.Date.AddDays(1).AddSeconds(-1);
            string titulo = _view.ReporteSeleccionado;

            switch (titulo)
            {
                case "Consulta de Deudas":
                    {
                        DataTable dt = await _logicaCreditos.ObtenerResumenDeudas("", "Monto DESC");

                        DataTable dtReporte = new DataTable();
                        dtReporte.Columns.Add("Nombre", typeof(string));
                        dtReporte.Columns.Add("Apellido", typeof(string));
                        dtReporte.Columns.Add("Cedula", typeof(string));
                        dtReporte.Columns.Add("Monto", typeof(decimal));
                        dtReporte.Columns.Add("Fecha", typeof(DateTime));
                        dtReporte.Columns.Add("Registrado Por", typeof(string));  
                        dtReporte.Columns.Add("Rol", typeof(string));               

                        foreach (DataRow r in dt.Rows)
                        {
                            dtReporte.Rows.Add(
                                r["Nombre"],
                                r["Apellido"],
                                r["Cedula"],
                                r["Monto"],
                                r["Fecha"],
                                r["RegistradoPor"], 
                                r["Rol"]              
                            );
                        }

                        return (FiltrarPorFecha(dtReporte, "Fecha", desde, hasta), titulo);
                    }

                case "Estado de Cuenta Individual":
                    {
                        var (cliente, detalle, total, dias) =
                            await _logicaCreditos.ObtenerDetalleDeuda(_view.CedulaCliente, 0);

                        if (cliente == null)
                            return (null, titulo);

                        string subtitulo = $"{cliente.Nombres} {cliente.Apellidos}  |  C.I.: {cliente.Cedula}";

                        DataTable dtFiltrado = FiltrarPorFecha(detalle, "Fecha", desde, hasta);
                        dtFiltrado.ExtendedProperties["TotalDeuda"] = total;
                        dtFiltrado.ExtendedProperties["DiasSinPagar"] = dias;

                        return (dtFiltrado, $"{titulo}||{subtitulo}");
                    }

                case "Consulta de Pagos":
                    {
                        DataTable dt = await _logicaPagos.ObtenerHistorialPagosPorRangoAsync(desde, hasta);

                        DataTable dtFinal = new DataTable();
                        dtFinal.Columns.Add("Nombre", typeof(string));
                        dtFinal.Columns.Add("Apellido", typeof(string));
                        dtFinal.Columns.Add("Cedula", typeof(string));
                        dtFinal.Columns.Add("Monto", typeof(decimal));
                        dtFinal.Columns.Add("Moneda", typeof(string));
                        dtFinal.Columns.Add("Monto Bs", typeof(decimal));
                        dtFinal.Columns.Add("Tipo", typeof(string));
                        dtFinal.Columns.Add("Fecha de Pago", typeof(DateTime));
                        dtFinal.Columns.Add("Registrado Por", typeof(string));   
                        dtFinal.Columns.Add("Rol", typeof(string));               

                        var gananciasPorMoneda = new Dictionary<string, decimal>();

                        foreach (DataRow r in dt.Rows)
                        {
                            string moneda = Campo(r, "NombreMoneda");
                            decimal monto = Convert.ToDecimal(CampoNum(r, "Monto"));

                            dtFinal.Rows.Add(
                                Campo(r, "Nombre"),
                                Campo(r, "Apellido"),
                                Campo(r, "Cedula"),
                                monto,
                                moneda,
                                CampoNum(r, "MontoBs"),
                                Campo(r, "TipoPago"),
                                CampoFecha(r, "FechaPago"),
                                Campo(r, "RegistradoPor"),   
                                Campo(r, "Rol")               
                            );

                            if (!gananciasPorMoneda.ContainsKey(moneda))
                                gananciasPorMoneda[moneda] = 0;
                            gananciasPorMoneda[moneda] += monto;
                        }

                        if (gananciasPorMoneda.Count > 0)
                            dtFinal.ExtendedProperties["Ganancias"] = gananciasPorMoneda;

                        return (dtFinal, titulo);
                    }


                case "Productos Actuales":
                    {

                        DataTable dtInventario = await _logicaInventario.ListarConPrecioBs();

                        DataTable dt = new DataTable();
                        dt.Columns.Add("Nombre", typeof(string));
                        dt.Columns.Add("Categoría", typeof(string));
                        dt.Columns.Add("Precio", typeof(decimal));
                        dt.Columns.Add("Precio Bs", typeof(string));
                        dt.Columns.Add("Stock", typeof(int));
                        dt.Columns.Add("Estado", typeof(string));

                        foreach (DataRow r in dtInventario.Rows)
                        {
                            dt.Rows.Add(
                                r["Nombre"],
                                r["NombreCategoria"],
                                r["Precio"],
                                r["PrecioBs"],
                                r["StockActual"],
                                r["EstadoVisual"]
                            );
                        }

                        return (dt, titulo);
                    }

                case "Historial de Cargos y Descargos":
                    {
                        var historial = await _logicaInventario.ListarHistorialOperaciones();
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Fecha", typeof(DateTime));
                        dt.Columns.Add("Tipo", typeof(string));
                        dt.Columns.Add("Producto", typeof(string));
                        dt.Columns.Add("Categoria", typeof(string));
                        dt.Columns.Add("Cantidad", typeof(int));
                        dt.Columns.Add("Motivo", typeof(string));

                        foreach (var op in historial)
                            dt.Rows.Add(op.Fecha, op.Tipo, op.Producto,
                                        op.Categoria, op.Cantidad, op.Motivo);

                        return (FiltrarPorFecha(dt, "Fecha", desde, hasta), titulo);
                    }

                default:
                    return (new DataTable(), titulo);
            }
        }

        private async void ExportarPDF_Accion(object sender, EventArgs e)
        {
            if (!ValidarEntrada()) return;


            try
            {
                var (dt, titulo) = await ObtenerDatos();
                if (dt == null || dt.Rows.Count == 0)
                {
                    _view.MostrarMensaje("No hay datos para el período seleccionado.", false);
                    return;
                }

                using (SaveFileDialog dlg = new SaveFileDialog
                {
                    Filter = "PDF (*.pdf)|*.pdf",
                    FileName = $"{titulo.Split(new[] { "||" }, StringSplitOptions.None)[0].Trim().Replace(" ", "_")}_{DateTime.Now:yyyyMMdd}.pdf"
                })
                {
                    if (dlg.ShowDialog() != DialogResult.OK) return;
                    GenerarPDF(dt, titulo, dlg.FileName);
                    Process.Start(new ProcessStartInfo(dlg.FileName) { UseShellExecute = true });
                }
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje("Error al generar PDF: " + ex.Message, true);
            }
        }

        private void GenerarPDF(DataTable dt, string titulo, string ruta)
        {
            string tituloPrincipal = titulo;
            string subtituloCliente = string.Empty;
            if (titulo.Contains("||"))
            {
                var partes = titulo.Split(new[] { "||" }, StringSplitOptions.None);
                tituloPrincipal = partes[0].Trim();
                subtituloCliente = partes[1].Trim();
            }

            bool apaisado = dt.Columns.Count > 5;
            PdfRect tamano = apaisado ? PageSize.A4.Rotate() : PageSize.A4;

            using (Document doc = new Document(tamano, 36, 36, 54, 36))
            using (FileStream fs = new FileStream(ruta, FileMode.Create))
            {
                PdfWriter.GetInstance(doc, fs);
                doc.Open();

                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                BaseFont bfB = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, false);
                iTextSharp.text.Font fTitulo = new iTextSharp.text.Font(bfB, 16);
                iTextSharp.text.Font fSub = new iTextSharp.text.Font(bf, 10, 0, BaseColor.GRAY);
                iTextSharp.text.Font fHeader = new iTextSharp.text.Font(bfB, 9, 0, BaseColor.WHITE);
                iTextSharp.text.Font fCelda = new iTextSharp.text.Font(bf, 9);
                iTextSharp.text.Font fCeldaB = new iTextSharp.text.Font(bfB, 9);

                PdfPTable encabezado = new PdfPTable(3);
                encabezado.WidthPercentage = 100;
                encabezado.SetWidths(new float[] { 1.2f, 5f, 1.2f });
                encabezado.SpacingAfter = 6;

                PdfPCell celdaLogo;
                try
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        Properties.Resources.Logo_V1.Save(
                            ms, System.Drawing.Imaging.ImageFormat.Png);

                        iTextSharp.text.Image logo =
                            iTextSharp.text.Image.GetInstance(ms.ToArray());
                        logo.ScaleToFit(70f, 55f);

                        celdaLogo = new PdfPCell(logo)
                        {
                            Border = PdfPCell.NO_BORDER,
                            VerticalAlignment = Element.ALIGN_MIDDLE,
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            Padding = 2
                        };
                    }
                }
                catch
                {
                    celdaLogo = new PdfPCell(
                        new Phrase("CT", new iTextSharp.text.Font(bfB, 20, 0, new BaseColor(30, 80, 162))))
                    {
                        Border = PdfPCell.NO_BORDER,
                        VerticalAlignment = Element.ALIGN_MIDDLE,
                        HorizontalAlignment = Element.ALIGN_LEFT,
                        Padding = 2
                    };
                }
                encabezado.AddCell(celdaLogo);

                iTextSharp.text.Font fNombreSistema =
                    new iTextSharp.text.Font(bfB, 13, 0, new BaseColor(30, 80, 162));

                Paragraph parTitulo = new Paragraph();
                parTitulo.Add(new Chunk("CrediTrack\n", fNombreSistema));
                parTitulo.Add(new Chunk(tituloPrincipal.ToUpper(), fTitulo));
                parTitulo.Alignment = Element.ALIGN_CENTER;

                encabezado.AddCell(new PdfPCell(parTitulo)
                {
                    Border = PdfPCell.NO_BORDER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Padding = 4
                });

                encabezado.AddCell(new PdfPCell()
                {
                    Border = PdfPCell.NO_BORDER
                });

                doc.Add(encabezado);

                PdfPTable linea = new PdfPTable(1);
                linea.WidthPercentage = 100;
                linea.SpacingAfter = 8;
                linea.AddCell(new PdfPCell()
                {
                    Border = 0,
                    FixedHeight = 2f,
                    BackgroundColor = new BaseColor(30, 80, 162)
                });
                doc.Add(linea);

                if (!string.IsNullOrEmpty(subtituloCliente))
                {
                    doc.Add(new Paragraph(subtituloCliente,
                        new iTextSharp.text.Font(bfB, 11, 0, BaseColor.BLACK))
                    { Alignment = Element.ALIGN_CENTER, SpacingAfter = 4 });
                }

                doc.Add(new Paragraph(
                    $"Período: {_view.FechaDesde:dd/MM/yyyy}  →  {_view.FechaHasta:dd/MM/yyyy}" +
                    $"   |   Generado: {DateTime.Now:dd/MM/yyyy HH:mm}", fSub)
                { Alignment = Element.ALIGN_CENTER, SpacingAfter = 14 });

                PdfPTable tabla = new PdfPTable(dt.Columns.Count)
                {
                    WidthPercentage = 100,
                    SpacingBefore = 4,
                    HeaderRows = 1
                };

                float[] anchos = new float[dt.Columns.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    string col = dt.Columns[i].ColumnName.ToLower();
                    if (col.Contains("fecha") || col.Contains("observ") ||
                        col.Contains("producto") || col.Contains("motivo") || col.Contains("categoria"))
                        anchos[i] = 2.5f;
                    else if (col.Contains("nombre") || col.Contains("apellido"))
                        anchos[i] = 2.0f;
                    else if (col.Contains("tipo"))
                        anchos[i] = 1.4f;
                    else if (col.Contains("id") || col.Contains("stock") || col.Contains("cantidad"))
                        anchos[i] = 1f;
                    else
                        anchos[i] = 1.5f;
                }
                tabla.SetWidths(anchos);

                BaseColor azulOscuro = new BaseColor(30, 80, 162);
                foreach (DataColumn col in dt.Columns)
                {
                    tabla.AddCell(new PdfPCell(new Phrase(col.ColumnName.ToUpper(), fHeader))
                    {
                        BackgroundColor = azulOscuro,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        Padding = 6,
                        BorderColor = BaseColor.WHITE
                    });
                }

                bool impar = false;
                BaseColor grisClaro = new BaseColor(245, 246, 248);
                int registrosReales = 0;

                foreach (DataRow row in dt.Rows)
                {
                    impar = !impar;
                    bool esTotalRow = false;
                    foreach (DataColumn c in dt.Columns)
                    {
                        if (row[c]?.ToString().StartsWith("TOTAL") == true)
                        { esTotalRow = true; break; }
                    }

                    bool esVacia = string.IsNullOrWhiteSpace(row[0]?.ToString()) && !esTotalRow;
                    if (!esTotalRow && !esVacia) registrosReales++;

                    foreach (DataColumn col in dt.Columns)
                    {
                        string valor;
                        if (row[col] == null || row[col] == DBNull.Value)
                        {
                            valor = "";
                        }
                        else if (dt.Columns[col.ColumnName].DataType == typeof(decimal)
                              || dt.Columns[col.ColumnName].DataType == typeof(double)
                              || dt.Columns[col.ColumnName].DataType == typeof(float))
                        {
                            if (decimal.TryParse(row[col].ToString(), out decimal num))
                                valor = num.ToString("N2",
                                    new System.Globalization.CultureInfo("es-VE"));
                            else
                                valor = row[col].ToString();
                        }
                        else
                        {
                            valor = row[col].ToString();
                        }
                        bool esBold = esTotalRow && valor.StartsWith("TOTAL");

                        BaseColor fondo = esTotalRow ? new BaseColor(219, 234, 254)
                                        : impar ? grisClaro
                                        : BaseColor.WHITE;

                        iTextSharp.text.Font fuenteCelda = esBold ? fCeldaB : fCelda;

                        if (tituloPrincipal == "Productos Actuales" && col.ColumnName == "Estado")
                        {
                            if (valor.Equals("Activo", StringComparison.OrdinalIgnoreCase))
                            {
                                fondo = new BaseColor(220, 245, 220);
                                fuenteCelda = new iTextSharp.text.Font(bfB, 9, 0, new BaseColor(0, 100, 0));
                            }
                            else if (valor.Equals("Stock bajo", StringComparison.OrdinalIgnoreCase))
                            {
                                fondo = new BaseColor(255, 243, 205);
                                fuenteCelda = new iTextSharp.text.Font(bfB, 9, 0, new BaseColor(133, 100, 4));
                            }
                            else if (valor.Equals("Agotado", StringComparison.OrdinalIgnoreCase))
                            {
                                fondo = new BaseColor(255, 220, 220);
                                fuenteCelda = new iTextSharp.text.Font(bfB, 9, 0, new BaseColor(139, 0, 0));
                            }
                        }

                        tabla.AddCell(new PdfPCell(new Phrase(valor, fuenteCelda))
                        {
                            BackgroundColor = fondo,
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            VerticalAlignment = Element.ALIGN_MIDDLE,
                            Padding = 6,
                            BorderColor = new BaseColor(220, 220, 220)
                        });
                    }
                }

                doc.Add(tabla);

                if (dt.ExtendedProperties.ContainsKey("Ganancias"))
                {
                    var ganancias = (Dictionary<string, decimal>)dt.ExtendedProperties["Ganancias"];
                    if (ganancias.Count > 0)
                    {
                        doc.Add(new Paragraph("\n"));
                        doc.Add(new Paragraph("RESUMEN DE GANANCIAS",
                            new iTextSharp.text.Font(bfB, 11, 0, new BaseColor(30, 80, 162)))
                        { SpacingAfter = 6 });

                        PdfPTable resumen = new PdfPTable(ganancias.Count);
                        resumen.WidthPercentage = 100;
                        resumen.SpacingBefore = 2;

                        float[] anchosResumen = new float[ganancias.Count];
                        for (int i = 0; i < ganancias.Count; i++) anchosResumen[i] = 1f;
                        resumen.SetWidths(anchosResumen);

                        BaseColor fondoTarjeta = new BaseColor(230, 247, 234);
                        BaseColor colorMonto = new BaseColor(21, 128, 61);
                        BaseColor colorEtiqueta = new BaseColor(90, 90, 90);

                        foreach (var kv in ganancias)
                        {
                            PdfPCell celda = new PdfPCell
                            {
                                BackgroundColor = fondoTarjeta,
                                BorderColor = new BaseColor(200, 220, 205),
                                Padding = 10,
                                HorizontalAlignment = Element.ALIGN_CENTER
                            };

                            Paragraph contenido = new Paragraph { Alignment = Element.ALIGN_CENTER };
                            contenido.Add(new Chunk($"{kv.Key.ToUpper()}\n",
                                new iTextSharp.text.Font(bfB, 8, 0, colorEtiqueta)));
                            contenido.Add(new Chunk(kv.Value.ToString("N2", new CultureInfo("es-VE")),
                                new iTextSharp.text.Font(bfB, 14, 0, colorMonto)));

                            celda.AddElement(contenido);
                            resumen.AddCell(celda);
                        }

                        doc.Add(resumen);
                    }
                }

                if (dt.ExtendedProperties.ContainsKey("TotalDeuda"))
                {
                    decimal totalDeuda = Convert.ToDecimal(dt.ExtendedProperties["TotalDeuda"]);
                    int diasSinPagar = Convert.ToInt32(dt.ExtendedProperties["DiasSinPagar"]);

                    bool esUrgente = diasSinPagar > 30;
                    BaseColor colorBorde = esUrgente ? new BaseColor(220, 38, 38) : new BaseColor(30, 80, 162);
                    BaseColor fondoTarjetaDeuda = esUrgente ? new BaseColor(254, 226, 226) : new BaseColor(219, 234, 254);
                    BaseColor colorMontoDeuda = esUrgente ? new BaseColor(185, 28, 28) : new BaseColor(30, 80, 162);
                    BaseColor colorEtiquetaDeuda = new BaseColor(90, 90, 90);

                    doc.Add(new Paragraph("\n"));

                    PdfPTable resumenDeuda = new PdfPTable(2);
                    resumenDeuda.WidthPercentage = 100;
                    resumenDeuda.SpacingBefore = 2;
                    resumenDeuda.SetWidths(new float[] { 1.6f, 1f });

                    PdfPCell celdaMonto = new PdfPCell
                    {
                        BackgroundColor = fondoTarjetaDeuda,
                        BorderColor = colorBorde,
                        BorderWidth = 1.2f,
                        Padding = 12,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    };
                    Paragraph pMonto = new Paragraph { Alignment = Element.ALIGN_CENTER };
                    pMonto.Add(new Chunk("TOTAL DEUDA\n", new iTextSharp.text.Font(bfB, 9, 0, colorEtiquetaDeuda)));
                    pMonto.Add(new Chunk($"{totalDeuda.ToString("N2", new CultureInfo("es-VE"))} $",
                        new iTextSharp.text.Font(bfB, 22, 0, colorMontoDeuda)));
                    celdaMonto.AddElement(pMonto);
                    resumenDeuda.AddCell(celdaMonto);

                    PdfPCell celdaDias = new PdfPCell
                    {
                        BackgroundColor = fondoTarjetaDeuda,
                        BorderColor = colorBorde,
                        BorderWidth = 1.2f,
                        Padding = 12,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    };
                    Paragraph pDias = new Paragraph { Alignment = Element.ALIGN_CENTER };
                    pDias.Add(new Chunk("DÍAS SIN PAGAR\n", new iTextSharp.text.Font(bfB, 9, 0, colorEtiquetaDeuda)));
                    pDias.Add(new Chunk(diasSinPagar.ToString(),
                        new iTextSharp.text.Font(bfB, 22, 0, colorMontoDeuda)));
                    celdaDias.AddElement(pDias);
                    resumenDeuda.AddCell(celdaDias);

                    doc.Add(resumenDeuda);
                }

                doc.Add(new Paragraph(
                    $"\nTotal de registros: {registrosReales}",
                    new iTextSharp.text.Font(bf, 8, 0, BaseColor.GRAY))
                { Alignment = Element.ALIGN_RIGHT });

                doc.Close();
            }
        }

        private bool ValidarEntrada()
        {
            if (_view.FechaDesde > _view.FechaHasta)
            {
                _view.MostrarMensaje("La fecha inicial no puede ser mayor que la fecha final.", true);
                return false;
            }

            if (_view.ReporteSeleccionado == "Estado de Cuenta Individual"
                && string.IsNullOrWhiteSpace(_view.CedulaCliente))
            {
                _view.MostrarMensaje("Debe seleccionar un cliente para este reporte.", true);
                return false;
            }

            return true;
        }

        private async void ExportarExcel_Accion(object sender, EventArgs e)
        {
            if (!ValidarEntrada()) return;

            try
            {
                var (dt, titulo) = await ObtenerDatos();
                if (dt == null || dt.Rows.Count == 0)
                {
                    _view.MostrarMensaje("No hay datos para el período seleccionado.", false);
                    return;
                }

                using (SaveFileDialog dlg = new SaveFileDialog
                {
                    Filter = "Excel (*.xlsx)|*.xlsx",
                    FileName = $"{titulo.Split(new[] { "||" }, StringSplitOptions.None)[0].Trim().Replace(" ", "_")}_{DateTime.Now:yyyyMMdd}.xlsx"
                })
                {
                    if (dlg.ShowDialog() != DialogResult.OK) return;
                    string rutaArchivo = dlg.FileName;
                    GenerarExcel(dt, titulo, rutaArchivo);
                    await System.Threading.Tasks.Task.Delay(300);
                    Process.Start(new ProcessStartInfo(rutaArchivo) { UseShellExecute = true });
                }
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje("Error al generar Excel: " + ex.Message, true);
            }
        }

        private void GenerarExcel(DataTable dt, string titulo, string ruta)
        {
            string tituloPrincipal = titulo;
            string subtituloCliente = string.Empty;
            if (titulo.Contains("||"))
            {
                var partes = titulo.Split(new[] { "||" }, StringSplitOptions.None);
                tituloPrincipal = partes[0].Trim();
                subtituloCliente = partes[1].Trim();
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Reporte");

                int filaActual = 1;

                ws.Cell(filaActual, 1).Value = tituloPrincipal.ToUpper();
                ws.Range(filaActual, 1, filaActual, dt.Columns.Count).Merge()
                    .Style.Font.SetBold().Font.SetFontSize(14)
                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                    .Fill.SetBackgroundColor(XLColor.FromArgb(30, 80, 162))
                    .Font.SetFontColor(XLColor.White);
                filaActual++;

                if (!string.IsNullOrEmpty(subtituloCliente))
                {
                    ws.Cell(filaActual, 1).Value = subtituloCliente;
                    ws.Range(filaActual, 1, filaActual, dt.Columns.Count).Merge()
                        .Style.Font.SetBold().Font.SetFontSize(11)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    filaActual++;
                }

                ws.Cell(filaActual, 1).Value =
                    $"Período: {_view.FechaDesde:dd/MM/yyyy}  →  {_view.FechaHasta:dd/MM/yyyy}" +
                    $"   |   Generado: {DateTime.Now:dd/MM/yyyy HH:mm}";
                ws.Range(filaActual, 1, filaActual, dt.Columns.Count).Merge()
                    .Style.Font.SetItalic()
                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                    .Font.SetFontColor(XLColor.Gray);
                filaActual++;

                var tabla = ws.Cell(filaActual, 1).InsertTable(dt, false);
                tabla.Theme = XLTableTheme.TableStyleMedium9;

                for (int i = 0; i < dt.Columns.Count; i++)
                    tabla.HeadersRow().Cell(i + 1).Value = dt.Columns[i].ColumnName;

                foreach (DataColumn col in dt.Columns)
                {
                    if (col.DataType == typeof(DateTime))
                    {
                        int colIdx = col.Ordinal + 1;
                        ws.Column(colIdx).Style.DateFormat.Format = "dd/MM/yyyy";
                    }
                    else if (col.DataType == typeof(decimal)
                          || col.DataType == typeof(double)
                          || col.DataType == typeof(float))
                    {
                        int colIdx = col.Ordinal + 1;
                        ws.Column(colIdx).Style.NumberFormat.Format = "#,##0.00";
                    }
                }

                int filaInicio = tabla.FirstRow().RowNumber() + 1;
                int filaFin = tabla.LastRow().RowNumber();

                for (int r = filaInicio; r <= filaFin; r++)
                {
                    bool esFilaTotal = false;
                    for (int c = 1; c <= dt.Columns.Count; c++)
                    {
                        if (ws.Cell(r, c).GetString().StartsWith("TOTAL"))
                        {
                            esFilaTotal = true;
                            break;
                        }
                    }
                    if (esFilaTotal)
                    {
                        ws.Range(r, 1, r, dt.Columns.Count)
                            .Style.Fill.SetBackgroundColor(XLColor.FromHtml("#DBEAFE"))
                            .Font.SetBold();
                    }
                }

                if (tituloPrincipal == "Productos Actuales" && dt.Columns.Contains("Estado"))
                {
                    int colEstado = dt.Columns["Estado"].Ordinal + 1;
                    for (int r = filaInicio; r <= filaFin; r++)
                    {
                        string valor = ws.Cell(r, colEstado).GetString();

                        if (valor.Equals("Activo", StringComparison.OrdinalIgnoreCase))
                        {
                            ws.Cell(r, colEstado).Style
                                .Fill.SetBackgroundColor(XLColor.FromArgb(220, 245, 220));
                            ws.Cell(r, colEstado).Style
                                .Font.SetFontColor(XLColor.FromArgb(0, 100, 0));
                        }
                        else if (valor.Equals("Stock bajo", StringComparison.OrdinalIgnoreCase))
                        {
                            ws.Cell(r, colEstado).Style
                                .Fill.SetBackgroundColor(XLColor.FromArgb(255, 243, 205));
                            ws.Cell(r, colEstado).Style
                                .Font.SetFontColor(XLColor.FromArgb(133, 100, 4));
                        }
                        else if (valor.Equals("Agotado", StringComparison.OrdinalIgnoreCase))
                        {
                            ws.Cell(r, colEstado).Style
                                .Fill.SetBackgroundColor(XLColor.FromArgb(255, 220, 220));
                            ws.Cell(r, colEstado).Style
                                .Font.SetFontColor(XLColor.FromArgb(139, 0, 0));
                        }
                    }
                }

                ws.Columns().AdjustToContents();
                foreach (var col in ws.Columns(1, dt.Columns.Count))
                    if (col.Width < 12) col.Width = 12;

                int registrosReales = 0;
                foreach (DataRow r in dt.Rows)
                {
                    bool tieneTotal = false;
                    bool todosVacios = true;
                    foreach (var item in r.ItemArray)
                    {
                        string val = item?.ToString() ?? "";
                        if (val.StartsWith("TOTAL")) { tieneTotal = true; break; }
                        if (!string.IsNullOrWhiteSpace(val)) todosVacios = false;
                    }
                    if (!tieneTotal && !todosVacios) registrosReales++;
                }

                int filaResumenInicio = filaFin + 2;
                int filaResumenActual = filaResumenInicio;

                if (dt.ExtendedProperties.ContainsKey("Ganancias"))
                {
                    var ganancias = (Dictionary<string, decimal>)dt.ExtendedProperties["Ganancias"];
                    if (ganancias.Count > 0)
                    {
                        ws.Cell(filaResumenActual, 1).Value = "RESUMEN DE GANANCIAS";
                        ws.Range(filaResumenActual, 1, filaResumenActual, 2).Merge()
                            .Style.Font.SetBold().Font.SetFontSize(11)
                            .Fill.SetBackgroundColor(XLColor.FromArgb(30, 80, 162))
                            .Font.SetFontColor(XLColor.White);
                        filaResumenActual++;

                        foreach (var kv in ganancias)
                        {
                            ws.Cell(filaResumenActual, 1).Value = kv.Key.ToUpper();
                            ws.Cell(filaResumenActual, 1).Style.Font.SetBold();

                            ws.Cell(filaResumenActual, 2).Value = kv.Value;
                            ws.Cell(filaResumenActual, 2).Style.NumberFormat.Format = "#,##0.00";
                            ws.Cell(filaResumenActual, 2).Style.Font.SetBold()
                                .Font.SetFontColor(XLColor.FromArgb(21, 128, 61));

                            ws.Range(filaResumenActual, 1, filaResumenActual, 2)
                                .Style.Fill.SetBackgroundColor(XLColor.FromArgb(230, 247, 234))
                                .Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                            filaResumenActual++;
                        }
                    }
                }

                if (dt.ExtendedProperties.ContainsKey("TotalDeuda"))
                {
                    decimal totalDeuda = Convert.ToDecimal(dt.ExtendedProperties["TotalDeuda"]);
                    int diasSinPagar = Convert.ToInt32(dt.ExtendedProperties["DiasSinPagar"]);

                    bool esUrgente = diasSinPagar > 30;
                    XLColor colorBorde = esUrgente ? XLColor.FromArgb(220, 38, 38) : XLColor.FromArgb(30, 80, 162);
                    XLColor fondoTarjetaDeuda = esUrgente ? XLColor.FromArgb(254, 226, 226) : XLColor.FromArgb(219, 234, 254);
                    XLColor colorMontoDeuda = esUrgente ? XLColor.FromArgb(185, 28, 28) : XLColor.FromArgb(30, 80, 162);
                    XLColor colorEtiquetaDeuda = XLColor.FromArgb(90, 90, 90);

                    int mitad = Math.Max(1, dt.Columns.Count / 2);

                    var etiquetaMonto = ws.Range(filaResumenActual, 1, filaResumenActual, mitad).Merge();
                    etiquetaMonto.Value = "TOTAL DEUDA";
                    etiquetaMonto.Style.Font.SetBold().Font.SetFontSize(9).Font.SetFontColor(colorEtiquetaDeuda);
                    etiquetaMonto.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    var etiquetaDias = ws.Range(filaResumenActual, mitad + 1, filaResumenActual, dt.Columns.Count).Merge();
                    etiquetaDias.Value = "DÍAS SIN PAGAR";
                    etiquetaDias.Style.Font.SetBold().Font.SetFontSize(9).Font.SetFontColor(colorEtiquetaDeuda);
                    etiquetaDias.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    filaResumenActual++;

                    var celdaMontoDeuda = ws.Range(filaResumenActual, 1, filaResumenActual, mitad).Merge();
                    celdaMontoDeuda.Value = totalDeuda;
                    celdaMontoDeuda.Style.NumberFormat.Format = "#,##0.00 \"$\"";
                    celdaMontoDeuda.Style.Font.SetBold().Font.SetFontSize(16).Font.SetFontColor(colorMontoDeuda);
                    celdaMontoDeuda.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    celdaMontoDeuda.Style.Fill.SetBackgroundColor(fondoTarjetaDeuda);
                    celdaMontoDeuda.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
                    celdaMontoDeuda.Style.Border.SetOutsideBorderColor(colorBorde);

                    var celdaDiasDeuda = ws.Range(filaResumenActual, mitad + 1, filaResumenActual, dt.Columns.Count).Merge();
                    celdaDiasDeuda.Value = diasSinPagar;
                    celdaDiasDeuda.Style.Font.SetBold().Font.SetFontSize(16).Font.SetFontColor(colorMontoDeuda);
                    celdaDiasDeuda.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    celdaDiasDeuda.Style.Fill.SetBackgroundColor(fondoTarjetaDeuda);
                    celdaDiasDeuda.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
                    celdaDiasDeuda.Style.Border.SetOutsideBorderColor(colorBorde);

                    filaResumenActual += 2;
                }

                int filaPie = filaResumenActual + 1;
                ws.Cell(filaPie, 1).Value = $"Total de registros: {registrosReales}";
                ws.Cell(filaPie, 1).Style.Font.SetItalic().Font.SetFontColor(XLColor.Gray);

                wb.SaveAs(ruta);
            }
        }

        private DataTable FiltrarPorFecha(DataTable dt, string columna, DateTime desde, DateTime hasta)
        {
            if (dt == null || !dt.Columns.Contains(columna)) return dt ?? new DataTable();

            DataTable resultado = dt.Clone();
            foreach (DataRow fila in dt.Rows)
            {
                if (fila[columna] == DBNull.Value || fila[columna] == null)
                {
                    resultado.ImportRow(fila);
                    continue;
                }
                if (DateTime.TryParse(fila[columna].ToString(), out DateTime fecha))
                    if (fecha >= desde && fecha <= hasta)
                        resultado.ImportRow(fila);
            }
            return resultado;
        }

        private static string Campo(DataRow r, string col) =>
    r.Table.Columns.Contains(col) && r[col] != DBNull.Value ? r[col].ToString() : "";

        private static object CampoNum(DataRow r, string col) =>
            r.Table.Columns.Contains(col) && r[col] != DBNull.Value ? r[col] : (object)0m;

        private static object CampoFecha(DataRow r, string col) =>
            r.Table.Columns.Contains(col) && r[col] != DBNull.Value ? r[col] : DBNull.Value;
    }
}