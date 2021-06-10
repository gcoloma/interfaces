using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using ILOG002.Infraestructure.Configuration;
using ILOG002.Infraestructure.Services;
using ILOG002.Models;
using ILOG002.Models._002.Request;
using ILOG002.Models._002.Response;
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
    public static class ILOGO002002
    {
        private static RegistroLog Logger = new RegistroLog();
        private static readonly Configuracion conf = new Configuracion();
        static IConfigurationRoot configuracion = conf.GetConfiguration();
        private static string sbUriConsumoWebService = Environment.GetEnvironmentVariable("UriConsumoWebService");
        private static string sbMetodoWsUriConsumowebService = Environment.GetEnvironmentVariable("MetodoWsUriConsumowebService");
        private static string sbUriHomologacionDynamic = Environment.GetEnvironmentVariable("UriHomologacionDynamicSiac");
        private static string sbMetodoWsUriSiac = Environment.GetEnvironmentVariable("MetodoWsUriSiac");
        private static string sbMetodoWsUriAx = Environment.GetEnvironmentVariable("MetodoWsUriAx");
        private static string sbQueueResponse = Environment.GetEnvironmentVariable("QueueResponse002");
        private static string sbConectionStringSend = Environment.GetEnvironmentVariable("ConectionStringResponse");

        [FunctionName("APILOGO002002")]
        public static async Task Run([ServiceBusTrigger("%QueueRequest002%", Connection = "ConectionStringRequest")] string myQueueItem, ILogger log)
        {
            try
            {
                Logger.FileLogger("APILOGO002002", "Procesando Funci�n");

                ResponseHomologacion respuesta = null;

                var APILOG002002Request = JsonConvert.DeserializeObject<APILOG002002MessageRequest>(myQueueItem);

                //Homologaci�n
                string DataAreaId = APILOG002002Request.DataAreaId;
                IManejadorHomologacion<ResponseHomologacion> _manejadorHomologacion = new ManejadorHomologacion<ResponseHomologacion>();

                respuesta = await _manejadorHomologacion.GetHomologacion(sbUriHomologacionDynamic, sbMetodoWsUriAx, DataAreaId);
                // mapear resultado homologacion
                APILOG002002Request.DataAreaId = respuesta?.Response ?? "000001";
                ////////////////////////////////////////////////////////////////
                //////////
                // ejecuta api
                ///
                string jsonData = JsonConvert.SerializeObject(APILOG002002Request);
                ConsumoWebService<ResponseWS> cws = new ConsumoWebService<ResponseWS>();
                ResponseWS objResponse = cws.PostWebService(sbUriConsumoWebService, sbMetodoWsUriConsumowebService, jsonData);
                // mapear la clase response del metodo con respuesta del WS
                Logger.FileLogger("APILOGO002002", "Resultado:" + objResponse.DescripcionId);
                //
                APILOG002002MessageResponse APILOG002002Response = new APILOG002002MessageResponse();
                string sesionid = APILOG002002Request.SessionId.ToString();
                //
                sesionid = Guid.NewGuid().ToString(); // hasta mientras, se debe borrar
                //
                APILOG002002Response.SessionId = sesionid;
                // falta mapeo resto de campos que responde WS

                IManejadorRequest<APILOG002002MessageResponse> _manejadorRequest = new ManejadorRequest<APILOG002002MessageResponse>();

                await _manejadorRequest.EnviarMensajeAsync(sesionid, sbConectionStringSend, sbQueueResponse, APILOG002002Response);
            }
            catch (Exception ex)
            {
                Logger.FileLogger("APILOGO002002", ex.ToString());
            }

        }
    }
}
