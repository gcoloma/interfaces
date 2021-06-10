using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ICXP003.Infraestructura.Servicios
{
    public interface IConsumoWebService<T>
     
    {
        T PostWebService(string uri, string method, string jsonData);

        Task<T> GetWebService(string uri, string method, string urlRequest);
    }
    public class ConsumoWebService<T> : IConsumoWebService<T>
    {
        private RestClient client;
        public T PostWebService(string uri, string method, string jsonData)
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
        public async Task<T> GetWebService(string uri, string method, string urlRequest)
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
