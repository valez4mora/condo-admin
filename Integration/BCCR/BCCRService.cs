using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Integration.BCCR
{
    public class BCCRService : IBCCRService
    {
        private readonly HttpClient _httpClient;

        private readonly string _url;
        private readonly string _nombre;
        private readonly string _correo;
        private readonly string _token;

        // Código oficial BCCR:
        // 317 = Compra
        // 318 = Venta
        private const int CODIGO_VENTA = 318;

        public BCCRService()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(20);

            _url = ConfigurationManager.AppSettings["URLBCCR"];
            _nombre = ConfigurationManager.AppSettings["NombreBCCR"];
            _correo = ConfigurationManager.AppSettings["CorreoBCCR"];
            _token = ConfigurationManager.AppSettings["TokenBCCR"];

            if (string.IsNullOrWhiteSpace(_url))
            {
                throw new ConfigurationErrorsException(
                    "No se encontró la configuración URLBCCR.");
            }

            if (string.IsNullOrWhiteSpace(_nombre))
            {
                throw new ConfigurationErrorsException(
                    "No se encontró la configuración NombreBCCR.");
            }

            if (string.IsNullOrWhiteSpace(_correo))
            {
                throw new ConfigurationErrorsException(
                    "No se encontró la configuración CorreoBCCR.");
            }

            if (string.IsNullOrWhiteSpace(_token))
            {
                throw new ConfigurationErrorsException(
                    "No se encontró la configuración TokenBCCR.");
            }

        }

        public BCCRResponseDTO ObtenerTipoCambioVenta()
        {
            try
            {
                if (_correo.Equals("TU_CORREO", StringComparison.OrdinalIgnoreCase) ||
                    _token.Equals("TU_TOKEN", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ConfigurationErrorsException(
                        "Debe reemplazar TU_CORREO y TU_TOKEN en App.config por las credenciales de suscripción del BCCR.");
                }

                DateTime fechaActual = DateTime.Today;
                DateTime fechaInicio = fechaActual.AddDays(-7);
                string inicio = fechaInicio.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                string fin = fechaActual.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                string urlConsulta =
                    _url +
                    "?Indicador=" + CODIGO_VENTA +
                    "&FechaInicio=" + Uri.EscapeDataString(inicio) +
                    "&FechaFinal=" + Uri.EscapeDataString(fin) +
                    "&Nombre=" + Uri.EscapeDataString(_nombre) +
                    "&SubNiveles=N" +
                    "&CorreoElectronico=" + Uri.EscapeDataString(_correo) +
                    "&Token=" + Uri.EscapeDataString(_token);

                HttpResponseMessage response =
                    _httpClient.GetAsync(urlConsulta).Result;

                if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
                {
                    throw new Exception(
                        "El servicio del BCCR no está disponible temporalmente. " +
                        "No fue posible realizar la conversión a dólares. " +
                        "Intente nuevamente más tarde.");
                }

                if (response.StatusCode == HttpStatusCode.Unauthorized ||
                    response.StatusCode == HttpStatusCode.Forbidden)
                {
                    throw new Exception(
                        "El BCCR rechazó las credenciales. Verifique el correo " +
                        "y el token configurados en App.config.");
                }

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(
                        "El BCCR respondió con el código HTTP " +
                        (int)response.StatusCode + " (" +
                        response.ReasonPhrase + ").");
                }

                string xml =
                    response.Content.ReadAsStringAsync().Result;

                XDocument documento = XDocument.Parse(xml);
                var nodos = documento.Descendants()
                    .Where(x => x.Name.LocalName == "INGC011_CAT_INDICADORECONOMIC")
                    .ToList();

                // Algunas respuestas ASMX contienen el XML real como texto escapado.
                if (nodos.Count == 0 && documento.Root != null &&
                    !string.IsNullOrWhiteSpace(documento.Root.Value) &&
                    documento.Root.Value.TrimStart().StartsWith("<"))
                {
                    documento = XDocument.Parse(documento.Root.Value);
                    nodos = documento.Descendants()
                        .Where(x => x.Name.LocalName == "INGC011_CAT_INDICADORECONOMIC")
                        .ToList();
                }

                XElement nodo = nodos
                    .OrderByDescending(ObtenerFechaNodo)
                    .FirstOrDefault();

                if (nodo == null)
                {
                    throw new Exception(
                        "El BCCR no devolvió información de venta para los últimos 7 días.");
                }

                XElement fechaNodo =
                    nodo.Elements()
                        .FirstOrDefault(x =>
                            x.Name.LocalName == "DES_FECHA");

                XElement valorNodo =
                    nodo.Elements()
                        .FirstOrDefault(x =>
                            x.Name.LocalName == "NUM_VALOR");

                if (valorNodo == null)
                {
                    throw new Exception(
                        "No se encontró el valor del tipo de cambio.");
                }

                decimal valor =
                    ParsearDecimalBccr(valorNodo.Value);

                DateTime fechaResultado =
                    fechaNodo != null
                        ? ParsearFechaBccr(fechaNodo.Value)
                        : fechaActual;

                return new BCCRResponseDTO
                {
                    CodigoIndicador = CODIGO_VENTA,
                    Fecha = fechaResultado,
                    Valor = valor
                };
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(
                    "No fue posible comunicarse con el servicio del BCCR.",
                    ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception(
                    "La consulta al BCCR superó el tiempo máximo de espera.",
                    ex);
            }
            catch (ConfigurationErrorsException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Ocurrió un error al consultar el tipo de cambio del BCCR: " + ex.Message,
                    ex);
            }
        }

        private static DateTime ObtenerFechaNodo(XElement nodo)
        {
            XElement fecha = nodo.Elements()
                .FirstOrDefault(x => x.Name.LocalName == "DES_FECHA");
            return fecha == null ? DateTime.MinValue : ParsearFechaBccr(fecha.Value);
        }

        private static DateTime ParsearFechaBccr(string texto)
        {
            DateTime fecha;
            string[] formatos = { "dd/MM/yyyy", "dd/MM/yyyy HH:mm:ss", "yyyy-MM-ddTHH:mm:ss" };
            return DateTime.TryParseExact(texto.Trim(), formatos,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha)
                ? fecha
                : DateTime.Parse(texto, CultureInfo.CurrentCulture);
        }

        private static decimal ParsearDecimalBccr(string texto)
        {
            decimal valor;
            if (decimal.TryParse(texto.Trim(), NumberStyles.Any,
                CultureInfo.InvariantCulture, out valor))
                return valor;
            if (decimal.TryParse(texto.Trim(), NumberStyles.Any,
                CultureInfo.GetCultureInfo("es-CR"), out valor))
                return valor;
            throw new FormatException("El valor devuelto por el BCCR no tiene un formato numérico válido.");
        }

        public decimal ConvertirColonesADolares(decimal colones)
        {
            BCCRResponseDTO tipoCambio =
                ObtenerTipoCambioVenta();

            if (tipoCambio.Valor <= 0)
            {
                throw new Exception(
                    "El tipo de cambio obtenido no es válido.");
            }

            return Math.Round(
                colones / tipoCambio.Valor,
                2);
        }

        public decimal ConvertirDolaresAColones(decimal dolares)
        {
            BCCRResponseDTO tipoCambio =
                ObtenerTipoCambioVenta();

            if (tipoCambio.Valor <= 0)
            {
                throw new Exception(
                    "El tipo de cambio obtenido no es válido.");
            }

            return Math.Round(
                dolares * tipoCambio.Valor,
                2);
        }
    }
}
