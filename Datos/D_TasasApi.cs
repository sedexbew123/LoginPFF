using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Datos
{
    public class D_TasasApi
    {
        private const string URL_COTIZACIONES = "https://ve.dolarapi.com/v1/cotizaciones";

        public async Task<List<CotizacionApi>> ObtenerCotizaciones(CancellationToken ct = default)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(15);
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64)");

                    HttpResponseMessage response = await client.GetAsync(URL_COTIZACIONES, ct);

                    if (!response.IsSuccessStatusCode) return null;

                    string json = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrWhiteSpace(json) || json.Trim() == "[]") return null;

                    return JsonConvert.DeserializeObject<List<CotizacionApi>>(json);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[D_TasasApi] {ex.Message}");

                return null;
            }
        }
    }
}
