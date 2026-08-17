using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Integration.TipoCambio
{
    public class TipoCambioService : ITipoCambioService
    {
        private const string URL_PREDETERMINADA =
            "https://open.er-api.com/v6/latest/USD";

        private readonly HttpClient _httpClient;
        private readonly string _url;

        public TipoCambioService()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            _httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(20)
            };

            string urlConfigurada =
                ConfigurationManager.AppSettings["URLTipoCambio"];

            _url = string.IsNullOrWhiteSpace(urlConfigurada)
                ? URL_PREDETERMINADA
                : urlConfigurada.Trim();
        }

        public TipoCambioResponseDTO ObtenerTipoCambio()
        {
            try
            {
                HttpResponseMessage respuesta =
                    _httpClient.GetAsync(_url).GetAwaiter().GetResult();

                if (!respuesta.IsSuccessStatusCode)
                {
                    throw new Exception(
                        "El servicio respondió con el código HTTP " +
                        (int)respuesta.StatusCode + " (" +
                        respuesta.ReasonPhrase + ").");
                }

                string json = respuesta.Content
                    .ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();

                JObject datos = JObject.Parse(json);
                string resultado = datos["result"] != null
                    ? datos["result"].ToString()
                    : string.Empty;

                if (!resultado.Equals(
                    "success",
                    StringComparison.OrdinalIgnoreCase))
                {
                    string tipoError = datos["error-type"] != null
                        ? datos["error-type"].ToString()
                        : "respuesta no válida";

                    throw new Exception(
                        "El proveedor no pudo procesar la consulta: " +
                        tipoError + ".");
                }

                JToken tokenCRC = datos["rates"] != null
                    ? datos["rates"]["CRC"]
                    : null;

                if (tokenCRC == null)
                {
                    throw new Exception(
                        "La respuesta no contiene la tasa para CRC.");
                }

                decimal valor;
                if (!decimal.TryParse(
                    tokenCRC.ToString(),
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out valor) || valor <= 0)
                {
                    throw new Exception(
                        "El tipo de cambio recibido no es válido.");
                }

                return new TipoCambioResponseDTO
                {
                    MonedaBase = datos["base_code"] != null
                        ? datos["base_code"].ToString()
                        : "USD",
                    MonedaDestino = "CRC",
                    Valor = valor,
                    FechaActualizacion = ObtenerFechaActualizacion(datos),
                    Proveedor = "ExchangeRate-API"
                };
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(
                    "No fue posible comunicarse con el servicio externo " +
                    "de tipo de cambio.", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception(
                    "La consulta del tipo de cambio superó el tiempo " +
                    "máximo de espera.", ex);
            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith(
                    "No fue posible comunicarse",
                    StringComparison.OrdinalIgnoreCase) ||
                    ex.Message.StartsWith(
                    "La consulta del tipo de cambio",
                    StringComparison.OrdinalIgnoreCase))
                {
                    throw;
                }

                throw new Exception(
                    "Ocurrió un error al consultar el tipo de cambio: " +
                    ex.Message, ex);
            }
        }

        public decimal ConvertirColonesADolares(decimal colones)
        {
            if (colones < 0)
            {
                throw new ArgumentOutOfRangeException(
                    "colones",
                    "El monto no puede ser negativo.");
            }

            decimal tipoCambio = ObtenerTipoCambio().Valor;
            return Math.Round(colones / tipoCambio, 2,
                MidpointRounding.AwayFromZero);
        }

        public decimal ConvertirDolaresAColones(decimal dolares)
        {
            if (dolares < 0)
            {
                throw new ArgumentOutOfRangeException(
                    "dolares",
                    "El monto no puede ser negativo.");
            }

            decimal tipoCambio = ObtenerTipoCambio().Valor;
            return Math.Round(dolares * tipoCambio, 2,
                MidpointRounding.AwayFromZero);
        }

        private static DateTime ObtenerFechaActualizacion(JObject datos)
        {
            JToken tokenUnix = datos["time_last_update_unix"];
            long segundos;

            if (tokenUnix != null && long.TryParse(
                tokenUnix.ToString(), out segundos))
            {
                return DateTimeOffset
                    .FromUnixTimeSeconds(segundos)
                    .LocalDateTime;
            }

            JToken tokenUtc = datos["time_last_update_utc"];
            DateTime fecha;

            if (tokenUtc != null && DateTime.TryParse(
                tokenUtc.ToString(),
                CultureInfo.InvariantCulture,
                DateTimeStyles.AssumeUniversal |
                DateTimeStyles.AdjustToUniversal,
                out fecha))
            {
                return fecha.ToLocalTime();
            }

            return DateTime.Now;
        }
    }
}
