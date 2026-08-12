using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
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
            _httpClient = new HttpClient();

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
                DateTime fechaActual = DateTime.Today;

                string fecha =
                    fechaActual.ToString("dd/MM/yyyy");

                string urlConsulta =
                    _url +
                    "?Indicador=" + CODIGO_VENTA +
                    "&FechaInicio=" + Uri.EscapeDataString(fecha) +
                    "&FechaFinal=" + Uri.EscapeDataString(fecha) +
                    "&Nombre=" + Uri.EscapeDataString(_nombre) +
                    "&SubNiveles=N" +
                    "&CorreoElectronico=" + Uri.EscapeDataString(_correo) +
                    "&Token=" + Uri.EscapeDataString(_token);

                HttpResponseMessage response =
                    _httpClient.GetAsync(urlConsulta).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(
                        "El servicio del BCCR respondió con código HTTP: "
                        + (int)response.StatusCode);
                }

                string xml =
                    response.Content.ReadAsStringAsync().Result;

                XDocument documento =
                    XDocument.Parse(xml);

                XElement nodo =
                    documento
                        .Descendants()
                        .FirstOrDefault(x =>
                            x.Name.LocalName == "INGC011_CAT_INDICADORECONOMIC");

                if (nodo == null)
                {
                    throw new Exception(
                        "El BCCR no devolvió información para la fecha consultada.");
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
                    decimal.Parse(
                        valorNodo.Value,
                        CultureInfo.InvariantCulture);

                DateTime fechaResultado =
                    fechaNodo != null
                        ? DateTime.Parse(fechaNodo.Value)
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
            catch (Exception ex)
            {
                throw new Exception(
                    "Ocurrió un error al consultar el tipo de cambio del BCCR.",
                    ex);
            }
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