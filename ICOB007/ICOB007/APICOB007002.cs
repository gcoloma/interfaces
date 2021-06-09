using System;
using System.Threading.Tasks;
using ICOB007.Infraestructura.Servicios;


using ICOB007.Models._002.Request;
using ICOB007.Models._002.Response;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static ICOB007.Infraestructura.Servicios.ManejadorRequestQueue;

namespace ICOB007
{
    public static class APICOB007002
    {
        private static string sbUriConsumoWebService = Environment.GetEnvironmentVariable("UriConsumoWebService002");
        private static string sbMetodoWsUriConsumowebService = Environment.GetEnvironmentVariable("MetodoWsUriConsumowebService002");
        public static string sbConenctionStringReceptar = Environment.GetEnvironmentVariable("ConectionStringRequest002");
         private static string nombrecolaresponse = Environment.GetEnvironmentVariable("QueueResponse002");
        private static string sbConenctionStringEnvio = Environment.GetEnvironmentVariable("ConectionStringResponse002");

        [FunctionName("APICOB007002")]
        public static async Task Run([ServiceBusTrigger("%QueueRequest002%", Connection = "ConectionStringRequest002")]string myQueueItem, ILogger log)
        {
            try
            {
                log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
                var APICOB007002Request = JsonConvert.DeserializeObject<APICOB007002MessageRequest>(myQueueItem);

                //////////
                // ejecuta api
                ///
                string jsonData = JsonConvert.SerializeObject(APICOB007002Request);
                ConsumoWebService<RespuestaWS002> cws = new ConsumoWebService<RespuestaWS002>();
                RespuestaWS002 objResponse = cws.PostWebService(sbUriConsumoWebService, sbMetodoWsUriConsumowebService, jsonData);
                // mapear la clase response del metodo con respuesta del WS

                //
                APICOB007002MessageResponse APICOB007002Response = new APICOB007002MessageResponse();
                string sesionid = APICOB007002Request.SessionId.ToString();
                //
                sesionid = Guid.NewGuid().ToString(); // hasta mientras, se debe borrar
                //
                APICOB007002Response.SessionId = sesionid;
                // falta mapeo resto de campos que responde WS

                IManejadorRequestQueue<APICOB007002MessageResponse> _manejadorRequestQueue = new ManejadorRequestQueue<APICOB007002MessageResponse>();

                await _manejadorRequestQueue.EnviarMensajeAsync(sesionid, sbConenctionStringEnvio, nombrecolaresponse, APICOB007002Response);

            }
            catch (Exception ex)
            {
                log.LogError($"Exception ICOB007002: {ex.Message}");
            }

        }
    }
    }

