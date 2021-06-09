using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using IVTA011.Infraestructura.Configuracion;
using Microsoft.Extensions.Configuration;
using IVTA011.Models._002.Request;
using Newtonsoft.Json;
using IVTA011.Infraestructura.Servicios;
using IVTA011.Models._002.Response;

namespace IVTA011
{
    public static class APIVTA011002
    {
        private static string sbUriConsumoWebService = Environment.GetEnvironmentVariable("UriConsumoWebService002");
        private static string sbMetodoWsUriConsumowebService = Environment.GetEnvironmentVariable("MetodoWsUriConsumowebService002");
        public static string sbConenctionStringReceptar = Environment.GetEnvironmentVariable("ConectionStringRequest002                                                                                                                                                                                                                                  ");
        //private static string nombrecolarequest = Environment.GetEnvironmentVariable("QueueRequest002");
        //private static string nombrecolaresponse = Environment.GetEnvironmentVariable("QueueResponse002");
        //private static string sbConenctionStringEnvio = Environment.GetEnvironmentVariable("ConectionStringResponse002");
        private static RegistroLog Logger = new RegistroLog();

        [FunctionName("IVTA011002")]
        public static async Task Run([ServiceBusTrigger("%QueueRequest002%", Connection = "ConectionStringRequest002")] string myQueueItem, ILogger log)
        {
            try
            {
                log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
                Logger.FileLogger("IVTA011002-Recibido: ", myQueueItem);
                var APIVTA011002Request = JsonConvert.DeserializeObject<APIVTA011002MessageRequest>(myQueueItem);
                ////////////////
                // ejecuta WS
                ///////////////
                string jsonData = JsonConvert.SerializeObject(APIVTA011002Request);
                ConsumoWebService<RespuestaWS002> cws = new ConsumoWebService<RespuestaWS002>();
                RespuestaWS002 objResponse = cws.PostWebService(sbUriConsumoWebService, sbMetodoWsUriConsumowebService, jsonData);

                /// 
                ///
              /*  APIVTA011002MessageResponse APIVTA011001Response = new APIVTA011002MessageResponse();
                string sesionid = Guid.NewGuid().ToString();
                APIVTA011001Response.SessionId = sesionid;

                // Esta funcion no responde, solo ejecuta web service
              */

            }
            catch (Exception ex)
            {
                Logger.FileLogger("IVTA011002", ex.ToString());
                log.LogError($"Exception IVTA011002:  {ex.Message}");
            }
        }
    }
}
