using System;
using System.Net.Http;
using System.Configuration;
using Newtonsoft.Json;
using DTO;

namespace Integration.Hacienda
{
    public class HaciendaService : IHaciendaService
    {
        private readonly HttpClient _httpClient;
        private readonly string _url;

        public HaciendaService()
        {
            _httpClient = new HttpClient();

            _url = ConfigurationManager
                .AppSettings["URLHacienda"];

            if (string.IsNullOrWhiteSpace(_url))
            {
                throw new ConfigurationErrorsException(
                    "No se encontró la configuración 'URLHacienda' en App.config.");
            }
        }

        public HaciendaResponseDTO ConsultarIdentificacion(
            string identificacion)
        {
            if (string.IsNullOrWhiteSpace(identificacion))
            {
                throw new ArgumentException(
                    "La identificación es requerida.",
                    nameof(identificacion));
            }

            string url = _url + identificacion;

            try
            {
                HttpResponseMessage response =
                    _httpClient.GetAsync(url).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(
                        "Hacienda respondió con el código HTTP: "
                        + (int)response.StatusCode);
                }

                string json =
                    response.Content.ReadAsStringAsync().Result;

                HaciendaResponseDTO resultado =
                    JsonConvert.DeserializeObject<HaciendaResponseDTO>(json);

                return resultado;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(
                    "No fue posible comunicarse con la API de Hacienda.",
                    ex);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Ocurrió un error al consultar la identificación.",
                    ex);
            }
        }
    }
}

