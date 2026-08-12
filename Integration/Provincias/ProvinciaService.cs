using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Provincias
{
    public class ProvinciaService : IProvinciaService
    {
        private readonly HttpClient _httpClient;
        private readonly string _url;

        public ProvinciaService()
        {
            _httpClient = new HttpClient();

            _url = ConfigurationManager
                .AppSettings["URLProvincias"];

            if (string.IsNullOrWhiteSpace(_url))
            {
                throw new ConfigurationErrorsException(
                    "No se encontró la configuración 'URLProvincias' en App.config.");
            }
        }

        public List<ProvinciaDTO> ObtenerProvincias()
        {
            try
            {
                HttpResponseMessage response =
                    _httpClient.GetAsync(_url).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(
                        "El servicio de provincias respondió con el código HTTP: "
                        + (int)response.StatusCode);
                }

                string json =
                    response.Content.ReadAsStringAsync().Result;

                List<ProvinciaDTO> provincias =
                    JsonConvert.DeserializeObject<List<ProvinciaDTO>>(json);

                return provincias ?? new List<ProvinciaDTO>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(
                    "No fue posible comunicarse con el servicio de provincias.",
                    ex);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Ocurrió un error al consultar las provincias.",
                    ex);
            }
        }
    }
}