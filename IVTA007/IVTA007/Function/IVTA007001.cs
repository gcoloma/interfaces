using System;
using System.Threading.Tasks;
using Interface.Api.Infraestructura.Configuracion;
using IVTA007.Infraestructure.Configuration;
using IVTA007.Infraestructure.Services;
using IVTA007.Models;
using IVTA007.Models._001.Request;
using IVTA007.Models._001.Response;
using IVTA007.Models.Homologacion.ResponseHomologacion;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static IVTA007.Services.ManejadorRequest;

namespace IVTA007
{
    public static class IVTA007001
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

        [FunctionName("APIVTA007001")]
        public static async Task Run([ServiceBusTrigger("%QueueRequest001%", Connection = "ConectionStringRequest")] string myQueueItem, ILogger log)
        {
            try
            {
                Logger.FileLogger("APIVTA007001", "Procesando Función");

                ResponseHomologacion respuesta = null;

                var APIVTA007001Request = JsonConvert.DeserializeObject<APIVTA007001MessageRequest>(myQueueItem);

                //Homologación
                string DataAreaId = APIVTA007001Request.DataAreaId;
                IManejadorHomologacion<ResponseHomologacion> _manejadorHomologacion = new ManejadorHomologacion<ResponseHomologacion>();

                respuesta = await _manejadorHomologacion.GetHomologacion(sbUriHomologacionDynamic, sbMetodoWsUriAx, DataAreaId);
                // mapear resultado homologacion
                APIVTA007001Request.DataAreaId = respuesta?.Response ?? "000001";
                ////////////////////////////////////////////////////////////////


                //////////
                // ejecuta api
                ///
                string jsonData = JsonConvert.SerializeObject(APIVTA007001Request);
                ConsumoWebService<ResponseWS> cws = new ConsumoWebService<ResponseWS>();
                ResponseWS objResponse = cws.PostWebService(sbUriConsumoWebService, sbMetodoWsUriConsumowebService, jsonData);
                // mapear la clase response del metodo con respuesta del WS
                Logger.FileLogger("APIVTA007001", "Resultado:" + objResponse.DescripcionId);
                //
                APIVTA007001MessageResponse APIVTA007001Response = new APIVTA007001MessageResponse();
                string sesionid = APIVTA007001Request.SessionId.ToString();
                //
                sesionid = Guid.NewGuid().ToString(); // hasta mientras, se debe borrar
                //
                APIVTA007001Response.SessionId = sesionid;
                // falta mapeo resto de campos que responde WS

                IManejadorRequest<APIVTA007001MessageResponse> _manejadorRequest = new ManejadorRequest<APIVTA007001MessageResponse>();

                await _manejadorRequest.EnviarMensajeAsync(sesionid, sbConectionStringSend, sbQueueResponse, APIVTA007001Response);

            }
            catch (Exception ex)
            {
                Logger.FileLogger("APIVTA007001", ex.ToString());
            }
        }
    }
}
