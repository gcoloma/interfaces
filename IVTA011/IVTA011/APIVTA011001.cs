using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using IVTA011.Infraestructura.Configuracion;
using Microsoft.Extensions.Configuration;
using IVTA011.Models._001.Request;
using Newtonsoft.Json;
using static IVTA011.Servicios.ManejadorRequestQueue;

namespace IVTA011
{
    public static class APIVTA011001
    {
      
        public static string sbConenctionStringReceptar = Environment.GetEnvironmentVariable("ConectionStringRequest001");
        private static string nombrecolarequest = Environment.GetEnvironmentVariable("QueueRequest001");
        private static string nombrecolaresponse = Environment.GetEnvironmentVariable("QueueResponse001");
        private static string sbConenctionStringEnvio = Environment.GetEnvironmentVariable("ConectionStringResponse001");

        [FunctionName("IVTA011001")]
        
        public static async Task Run([ServiceBusTrigger("%QueueRequest001%", Connection = "ConectionStringRequest001")] string myQueueItem, ILogger log)
        {
            try
            {
                log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
                var APIVTA011001Request = JsonConvert.DeserializeObject<APIVTA011001MessageRequest>(myQueueItem);
             
                //////////
                // ejecuta api
                ////////
                ////////

                APIVTA011001MessageResponse APIVTA011001Response = new APIVTA011001MessageResponse();
                string sesionid = APIVTA011001Request.SessionId.ToString();
                //
                sesionid = Guid.NewGuid().ToString(); // hasta mientras, se debe borrar
                //
                APIVTA011001Response.SessionId = sesionid;
                                          
                IManejadorRequestQueue<APIVTA011001MessageResponse> _manejadorRequestQueue = new ManejadorRequestQueue<APIVTA011001MessageResponse>();

                await _manejadorRequestQueue.EnviarMensajeAsync(sesionid, sbConenctionStringEnvio, nombrecolaresponse, APIVTA011001Response);
                                
            }
            catch (Exception ex)
            {
                log.LogError($"Exception IVTA011002: {ex.Message}");
            }
            
        }
    }
}

