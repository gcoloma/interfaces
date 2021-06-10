using System;
using System.IO;
using System.Threading.Tasks;

using ISAC018.Models._001.Resquest;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using ISAC018.Models._001.Response;
using NSwag.Annotations;
using System.Net.Http;
using Microsoft.Azure.WebJobs.Extensions.Http;
using ISAC018.Infraestructura.Configuracion;
using ISAC018.Infraestructura.Servicios;


namespace ISAC018
{
    public static class APISAC018001
    {
      
        private static string sbUriConsumoWebService = Environment.GetEnvironmentVariable("UriConsumoWebService");
        private static string sbMetodoWsUriConsumowebService = Environment.GetEnvironmentVariable("MetodoWsUriConsumowebService");
        //public static string sbConenctionStringReceptar = Environment.GetEnvironmentVariable("ConectionStringRequest001");
        //private static string nombrecolarequest = Environment.GetEnvironmentVariable("QueueRequest001");
        //private static string nombrecolaresponse = Environment.GetEnvironmentVariable("QueueResponse001");
        //private static string sbConenctionStringEnvio = Environment.GetEnvironmentVariable("ConectionStringResponse001");
        private static RegistroLog Logger = new RegistroLog();

        [FunctionName("APISAC018001")]
        public static async Task Run([ServiceBusTrigger("%QueueRequest001%", Connection = "ConectionStringRequest001")] string myQueueItem, ILogger log)
        {
        
            try
            {
                log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
                Logger.FileLogger("ISAC018-Recibido: ", myQueueItem);
                var APISAC018001Request = JsonConvert.DeserializeObject<APISAC018001MessageRequest>(myQueueItem);

                //////////
                // ejecuta web service
                ////////
                ///
                string jsonData = JsonConvert.SerializeObject(APISAC018001Request);
                                                   
                ConsumoWebService<RespuestaWS> cws = new ConsumoWebService<RespuestaWS>();
                RespuestaWS objResponse = cws.PostWebService(sbUriConsumoWebService, sbMetodoWsUriConsumowebService,jsonData);
               
            }
            catch (Exception ex)
            {
                Logger.FileLogger("ISAC018", ex.ToString());
                log.LogError($"Exception ISAC018001: {ex.Message}");

            }

    }
        }
}
