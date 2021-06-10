using System;
using System.Threading.Tasks;
using ICOB007.Infraestructura.Servicios;
using ICOB007.Models._001.Request;
using ICOB007.Models._001.Response;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static ICOB007.Infraestructura.Servicios.ManejadorRequestQueue;

namespace ICOB007
{
    public static class APICOB007001
    {
        private static string sbUriConsumoWebService = Environment.GetEnvironmentVariable("UriConsumoWebService001");
        private static string sbMetodoWsUriConsumowebService = Environment.GetEnvironmentVariable("MetodoWsUriConsumowebService001");
        public static string sbConenctionStringReceptar = Environment.GetEnvironmentVariable("ConectionStringRequest001");
        private static string nombrecolaresponse = Environment.GetEnvironmentVariable("QueueResponse001");
        private static string sbConenctionStringEnvio = Environment.GetEnvironmentVariable("ConectionStringResponse001");

        [FunctionName("APICOB007001")]
        public static async Task Run([ServiceBusTrigger("%QueueRequest001%", Connection = "ConectionStringRequest001")]string myQueueItem, ILogger log)
        {
            try
            {
                log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
                var APICOB007001Request = JsonConvert.DeserializeObject<APICOB007001MessageRequest>(myQueueItem);

                //////////
                // ejecuta api
                ///
                string jsonData = JsonConvert.SerializeObject(APICOB007001Request);
                ConsumoWebService<RespuestaWS001> cws = new ConsumoWebService<RespuestaWS001>();
                RespuestaWS001 objResponse = cws.PostWebService(sbUriConsumoWebService, sbMetodoWsUriConsumowebService, jsonData);
                // mapear la clase response del metodo con respuesta del WS

                //
                APICOB007001MessageResponse APICOB007001Response = new APICOB007001MessageResponse();
                string sesionid = APICOB007001Request.SessionId.ToString();
                //
                sesionid = Guid.NewGuid().ToString(); // hasta mientras, se debe borrar
                //
                APICOB007001Response.SessionId = sesionid;
                // falta mapeo resto de campos que responde WS

                IManejadorRequestQueue<APICOB007001MessageResponse> _manejadorRequestQueue = new ManejadorRequestQueue<APICOB007001MessageResponse>();

                await _manejadorRequestQueue.EnviarMensajeAsync(sesionid, sbConenctionStringEnvio, nombrecolaresponse, APICOB007001Response);

            }
            catch (Exception ex)
            {
                log.LogError($"Exception ICOB007001: {ex.Message}");
            }

        }
    }
}
