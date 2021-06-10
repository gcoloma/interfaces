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
using IVTA011.Infraestructura.Servicios;
using IVTA011.Models._001.Response;

namespace IVTA011
{
    public static class APIVTA011001
    {
        private static string sbUriConsumoWebService = Environment.GetEnvironmentVariable("UriConsumoWebService001");
        private static string sbMetodoWsUriConsumowebService = Environment.GetEnvironmentVariable("MetodoWsUriConsumowebService001");
        public static string sbConenctionStringReceptar = Environment.GetEnvironmentVariable("ConectionStringRequest001");
       // private static string nombrecolarequest = Environment.GetEnvironmentVariable("QueueRequest001");
        private static string nombrecolaresponse = Environment.GetEnvironmentVariable("QueueResponse001");
        private static string sbConenctionStringEnvio = Environment.GetEnvironmentVariable("ConectionStringResponse001");
        private static RegistroLog Logger = new RegistroLog();

        [FunctionName("IVTA011001")]
        
        public static async Task Run([ServiceBusTrigger("%QueueRequest001%", Connection = "ConectionStringRequest001")] string myQueueItem, ILogger log)
        {
            try
            {
                log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
                Logger.FileLogger("IVTA011001-Recibido: ", myQueueItem);
                var APIVTA011001Request = JsonConvert.DeserializeObject<APIVTA011001MessageRequest>(myQueueItem);

                //////////
                // ejecuta api
                ///
                string jsonData = JsonConvert.SerializeObject(APIVTA011001Request);
                ConsumoWebService<RespuestaWS001> cws = new ConsumoWebService<RespuestaWS001>();
                RespuestaWS001 objResponse = cws.PostWebService(sbUriConsumoWebService, sbMetodoWsUriConsumowebService, jsonData);
                // mapear la clase response del metodo con respuesta del WS

                //
                APIVTA011001MessageResponse APIVTA011001Response = new APIVTA011001MessageResponse();
                string sesionid = APIVTA011001Request.SessionId.ToString();
                //
                sesionid = Guid.NewGuid().ToString(); // hasta mientras, se debe borrar
                //
                APIVTA011001Response.SessionId = sesionid;
                // falta mapeo resto de campos que responde WS
                                          
                IManejadorRequestQueue<APIVTA011001MessageResponse> _manejadorRequestQueue = new ManejadorRequestQueue<APIVTA011001MessageResponse>();

                await _manejadorRequestQueue.EnviarMensajeAsync(sesionid, sbConenctionStringEnvio, nombrecolaresponse, APIVTA011001Response);
                                
            }
            catch (Exception ex)
            {
                Logger.FileLogger("IVTA011001", ex.ToString());
                log.LogError($"Exception IVTA011001: {ex.Message}");
            }
            
        }
    }
}

