using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Integration.Hacienda
{
    public class HaciendaService : IHaciendaService
    {
        private readonly HttpClient _httpClient;

        private const string URL =
            "https://api.hacienda.go.cr/fe/ae?identificacion=";

        private readonly string _url;

        public HaciendaService()
        {
            _httpClient = new HttpClient();

            _url = ConfigurationManager
                .AppSettings["URLHacienda"];
        }



        public HaciendaResponseDTO ConsultarIdentificacion(
            string identificacion)
        {
            if (string.IsNullOrWhiteSpace(identificacion))
            {
                throw new ArgumentException(
                    "La identificación es requerida.");
            }

            string url = URL + identificacion;

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
                    JsonConvert.DeserializeObject<HaciendaResponseDTO>(
                        json);

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
