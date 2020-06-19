using Avianca.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Avianca.Services
{
    public class AviancaServices
    {
        public static List<ControlDespegue> GetControlDespegue()
        {
            var client = new RestClient("https://localhost:44391");
            var request = new RestRequest("ControlDespegues/IndexJson", Method.GET);

            IRestResponse<List<ControlDespegue>> response = client.Execute<List<ControlDespegue>>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data; // raw content as string
            }
            else
            {
                return null;
            }
        }
        public static List<ControlAterrizaje> GetControlAterrizaje()
        {
            var client = new RestClient("https://localhost:44391");
            var request = new RestRequest("ControlAterrizajes/IndexJson", Method.GET);

            IRestResponse<List<ControlAterrizaje>> response = client.Execute<List<ControlAterrizaje>>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data; // raw content as string
            }
            else
            {
                return null;
            }
        }

        public static async Task<bool> SaveReservaAeropuerto(ReservaDespegue reservaDespegue)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44391/")
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var requestContent = new MultipartFormDataContent();
            var values = new Dictionary<string, string>
            {
                { "IDReservaDespegue", reservaDespegue.IDReservaDespegue.ToString() },
                { "Pista", reservaDespegue.Pista },
                { "Clima", reservaDespegue.Clima },
                { "Aerolinea", "Avianca" },
                { "FechayHora", reservaDespegue.FechayHora.ToString() }
               
            };
            var content = new FormUrlEncodedContent(values);
            requestContent.Add(content);

            HttpResponseMessage response = await client.PostAsync("ReservaDespegues/SaveReservaAPI", content);
            string responseText = await response.Content.ReadAsStringAsync();

            response.Dispose();

            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }




    }
}
