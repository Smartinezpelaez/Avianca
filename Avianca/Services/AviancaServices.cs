using Avianca.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
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

       


    }
}
