using System;
using System.IO;
using System.Threading.Tasks;
using ISAC020.Infraestructure;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.Azure.WebJobs.Extensions.Http;
using ISAC020.Models.Request;
using ISAC020.Models;
using ISAC020.Infraestructure.Configuration;
using Interface.Api.Infraestructura.Configuracion;
using ISAC020.Models.ResponseHomologacion;
using ISAC020.Infraestructure.Services;



namespace ISAC020
{
    public static class APISAC020002
    {
        private static RegistroLog Logger = new RegistroLog();
        private static readonly Configuracion conf = new Configuracion();
        static IConfigurationRoot configuracion = conf.GetConfiguration();
        private static string sbUriConsumoWebService = Environment.GetEnvironmentVariable("UriConsumoWebService");
        private static string sbMetodoWsUriConsumowebService = Environment.GetEnvironmentVariable("MetodoWsUriConsumowebService");
      

        [FunctionName("APISAC020002")]
        public static async Task Run([ServiceBusTrigger("%QueueRequest001%", Connection = "ConectionStringRequest001")] string myQueueItem, ILogger log)
        {

            try
            {
               
                Logger.FileLogger("APISAC020002", "Procesando Función");               

                var APISAC020002Request = JsonConvert.DeserializeObject<APISAC020002MessageRequest>(myQueueItem);

                string jsonData = JsonConvert.SerializeObject(APISAC020002Request);

                Logger.FileLogger("APISAC020002", "Json:" + jsonData);

                ConsumoWebService<ResponseWS> cws = new ConsumoWebService<ResponseWS>();
                ResponseWS objResponse = cws.PostWebService(sbUriConsumoWebService, sbMetodoWsUriConsumowebService, jsonData);

                Logger.FileLogger("APISAC020002", "Resultado:"+ objResponse.DescripcionId);
            }
            catch (Exception ex)
            {
                Logger.FileLogger("APISAC020002", ex.ToString());
            }

        }
    }
}
