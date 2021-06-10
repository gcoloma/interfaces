using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using ILOG002.Infraestructure.Configuration;
using ILOG002.Infraestructure.Services;
using ILOG002.Models;
using ILOG002.Models._001.Request;
using ILOG002.Models._001.Response;
using ILOG002.Models.Homologacion.ResponseHomologacion;
using Interface.Api.Infraestructura.Configuracion;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static ILOG002.Services.ManejadorRequest;

namespace ILOG002
{
    public static class ILOGO002001
    {
        private static RegistroLog Logger = new RegistroLog();
        private static readonly Configuracion conf = new Configuracion();
        static IConfigurationRoot configuracion = conf.GetConfiguration();
        private static string sbUriConsumoWebService = Environment.GetEnvironmentVariable("UriConsumoWebService");
        private static string sbMetodoWsUriConsumowebService = Environment.GetEnvironmentVariable("MetodoWsUriConsumowebService");
        private static string sbUriHomologacionDynamic = Environment.GetEnvironmentVariable("UriHomologacionDynamicSiac");
        private static string sbMetodoWsUriSiac = Environment.GetEnvironmentVariable("MetodoWsUriSiac");
        private static string sbMetodoWsUriAx = Environment.GetEnvironmentVariable("MetodoWsUriAx");
        private static string sbQueueResponse = Environment.GetEnvironmentVariable("QueueResponse001");
        private static string sbConectionStringSend = Environment.GetEnvironmentVariable("ConectionStringResponse");

        [FunctionName("APILOGO002001")]
        public static async Task Run([ServiceBusTrigger("%QueueRequest001%", Connection = "ConectionStringRequest")] string myQueueItem, ILogger log)
        {
            try
            {
                Logger.FileLogger("APILOGO002001", "Procesando Función");

                ResponseHomologacion respuesta = null;

                var APILOG002001Request = JsonConvert.DeserializeObject<APILOG002001MessageRequest>(myQueueItem);

                //Homologación
                string DataAreaId = APILOG002001Request.DataAreaId;
                IManejadorHomologacion<ResponseHomologacion> _manejadorHomologacion = new ManejadorHomologacion<ResponseHomologacion>();

                respuesta = await _manejadorHomologacion.GetHomologacion(sbUriHomologacionDynamic, sbMetodoWsUriAx, DataAreaId);
                // mapear resultado homologacion
                APILOG002001Request.DataAreaId = respuesta?.Response ?? "000001";
                ////////////////////////////////////////////////////////////////


                //////////
                // ejecuta api
                ///
                string jsonData = JsonConvert.SerializeObject(APILOG002001Request);
                ConsumoWebService<ResponseWS> cws = new ConsumoWebService<ResponseWS>();
                ResponseWS objResponse = cws.PostWebService(sbUriConsumoWebService, sbMetodoWsUriConsumowebService, jsonData);
                // mapear la clase response del metodo con respuesta del WS
                Logger.FileLogger("APILOGO002001", "Resultado:" + objResponse.DescripcionId);
                //
                APILOG002001MessageResponse APILOG002001Response = new APILOG002001MessageResponse();
                string sesionid = APILOG002001Request.SessionId.ToString();
                //
                sesionid = Guid.NewGuid().ToString(); // hasta mientras, se debe borrar
                //
                APILOG002001Response.SessionId = sesionid;
                // falta mapeo resto de campos que responde WS

                IManejadorRequest<APILOG002001MessageResponse> _manejadorRequest = new ManejadorRequest<APILOG002001MessageResponse>();

                await _manejadorRequest.EnviarMensajeAsync(sesionid, sbConectionStringSend, sbQueueResponse, APILOG002001Response);

            }
            catch (Exception ex)
            {
                Logger.FileLogger("APILOGO002001", ex.ToString());
            }

        }
    }
}
