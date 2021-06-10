using System;
using System.Threading.Tasks;
using APICAJ008002.Infraestructura.Configuracion;
using APICAJ008002.Infraestructura.Servicios;
using APICAJ008002.Models._002.Request;
using APICAJ008002.Models._002.Response;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static APICAJ008002.Infraestructura.Servicios.ManejadorRequestQueue;

namespace APICAJ008002
{
    public static class APICAJ008002
    {
        private static string sbUriConsumoWebService = Environment.GetEnvironmentVariable("UriConsumoWebService002");
        private static string sbMetodoWsUriConsumowebService = Environment.GetEnvironmentVariable("MetodoWsUriConsumowebService002");
        public static string sbConenctionStringReceptar = Environment.GetEnvironmentVariable("ConectionStringRequest002");
        private static string nombrecolaresponse = Environment.GetEnvironmentVariable("QueueResponse002");
        private static string sbConenctionStringEnvio = Environment.GetEnvironmentVariable("ConectionStringResponse002");
        private static RegistroLog Logger = new RegistroLog();

        [FunctionName("APICAJ008002")]
        public static async Task Run([ServiceBusTrigger("%QueueRequest001%", Connection = "ConectionStringRequest001")] string myQueueItem, ILogger log)
        {
            try
            {
                log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
                Logger.FileLogger("ICAJ008002-Recibido: ", myQueueItem);
                var APICAJ008002Request = JsonConvert.DeserializeObject<APICAJ008002MessageRequest>(myQueueItem);

                //////////
                // ejecuta api
                ///
                string jsonData = JsonConvert.SerializeObject(APICAJ008002Request);
                ConsumoWebService<RespuestaWS001> cws = new ConsumoWebService<RespuestaWS001>();
                RespuestaWS001 objResponse = cws.PostWebService(sbUriConsumoWebService, sbMetodoWsUriConsumowebService, jsonData);
                // mapear la clase response del metodo con respuesta del WS

                //
                APICAJ008002MessageResponse APICAJ008002Response = new APICAJ008002MessageResponse();
                string sesionid = APICAJ008002Request.SessionId.ToString();
                //
                sesionid = Guid.NewGuid().ToString(); // hasta mientras, se debe borrar
                //
                APICAJ008002Response.SessionId = sesionid;
                // falta mapeo resto de campos que responde WS

                IManejadorRequestQueue<APICAJ008002MessageResponse> _manejadorRequestQueue = new ManejadorRequestQueue<APICAJ008002MessageResponse>();

                await _manejadorRequestQueue.EnviarMensajeAsync(sesionid, sbConenctionStringEnvio, nombrecolaresponse, APICAJ008002Response);

            }
            catch (Exception ex)
            {
                Logger.FileLogger("ICAJ008002", ex.ToString());
                log.LogError($"Exception ICAJ008002: {ex.Message}");
            }

        }
    }
}

