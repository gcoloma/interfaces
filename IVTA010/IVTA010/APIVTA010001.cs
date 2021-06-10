using System;
using System.Threading.Tasks;
using IVTA010.Infraestructura.Servicios;
using IVTA010.Models._001;
using IVTA010.Models._001.Request;
using IVTA010.Models._001.Response;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static IVTA010.Infraestructura.Servicios.ManejadorRequestQueue;

namespace IVTA010
{
    public static class APIVTA010001

    {
        private static string sbUriConsumoWebService = Environment.GetEnvironmentVariable("UriConsumoWebService");
        private static string sbMetodoWsUriConsumowebService = Environment.GetEnvironmentVariable("MetodoWsUriConsumowebService");
        private static string nombrecolaresponse = Environment.GetEnvironmentVariable("QueueResponse001");
        private static string sbConenctionStringEnvio = Environment.GetEnvironmentVariable("ConectionStringResponse001");
        private static string Entorno = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");



        [FunctionName("APIVTA010001")]
        public static async Task Run([ServiceBusTrigger("%QueueRequest001%", Connection = "ConectionStringRequest001")] string myQueueItem, ILogger log)
        {

            try
            {
                log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
                var APIVTA010001Request = JsonConvert.DeserializeObject<APIVTA010001MessageRequest>(myQueueItem);

                //////////
                // ejecuta web service
                ////////
                ///
                // preguntar si el campo enviroment se llena con lo que se lee del SETTiNG
                //o con lo que nos envia del request, no se hace nada
                APIVTA010001Request.Enviroment = Entorno;

                string jsonData = JsonConvert.SerializeObject(APIVTA010001Request);

                ConsumoWebService<RespuestaWS> cws = new ConsumoWebService<RespuestaWS>();
                RespuestaWS objResponse = cws.PostWebService(sbUriConsumoWebService, sbMetodoWsUriConsumowebService, jsonData);

                APIVTA010001MessageResponse APIVTA010001Response = new APIVTA010001MessageResponse();
                string sesionid = APIVTA010001Request.SessionId.ToString();
                //
                sesionid = Guid.NewGuid().ToString(); // hasta mientras, se debe borrar
                //
                APIVTA010001Response.SessionId = sesionid;
                // falta mapeo resto de campos que responde WS

                IManejadorRequestQueue<APIVTA010001MessageResponse> _manejadorRequestQueue = new ManejadorRequestQueue<APIVTA010001MessageResponse>();

                await _manejadorRequestQueue.EnviarMensajeAsync(sesionid, sbConenctionStringEnvio, nombrecolaresponse, APIVTA010001Response);


            }
            catch (Exception ex)
            {
                log.LogError($"Exception IVTA010001: {ex.Message}");
            }
        }
    }
}
    
    
