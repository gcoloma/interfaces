using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ICAJ020.api.Infraestructura.Servicios
{
    public interface IHomologacionService<T>
    {
        T PostHomologacion(string uri, string method, string jsonData);

        Task<T> GetHomologacion(string uri, string method, string urlRequest);
    }
    public class HomologacionService<T> : IHomologacionService<T>
    {
        private RestClient client;
        public T PostHomologacion(string uri, string method, string jsonData)
        {
            try
            {
                client = new RestClient(uri);

                var request = new RestRequest(method, Method.POST, DataFormat.Json);

                request.AddParameter("application/json", jsonData, ParameterType.RequestBody);
                var response = client.Post(request);
                var content = response.Content;

                var resultadoApi = JsonConvert.DeserializeObject<T>(content);

                client = null;
                request = null;
                return resultadoApi;
            }
            catch (Exception)
            {
                client = null;
                throw;
            }
        }
        public async Task<T> GetHomologacion(string uri, string method, string urlRequest)
        {
            try
            {
                T resultadoApi = default(T);
                client = new RestClient(uri);


                string finalPath = $"{method}/{urlRequest}";
                var request = new RestRequest(finalPath, Method.GET);
                ;
                var response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var content = response.Content;
                    resultadoApi = JsonConvert.DeserializeObject<T>(content);
                }
                client = null;
                request = null;
                return resultadoApi;
            }
            catch (Exception)
            {
                client = null;
                throw;
            }
        }
    }

}
