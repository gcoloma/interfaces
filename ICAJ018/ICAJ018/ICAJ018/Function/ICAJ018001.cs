using System;
using System.Text;
using System.Threading.Tasks;
using ICAJ018.Infraestructure.Configuration;
using ICAJ018.Infraestructure.Services;
using ICAJ018.Models;
using ICAJ018.Models._001.Request;
using ICAJ018.Models._001.Response;
using ICAJ018.Models.Homologacion.ResponseHomologacion;
using ICAJ018.Models.Response;
using Interface.Api.Infraestructura.Configuracion;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static ICAJ018.Services.ManejadorRequest;

namespace ICAJ018
{
    public static class ICAJ018001
    {
        private static RegistroLog Logger = new RegistroLog();
        private static readonly Configuracion conf = new Configuracion();
        static IConfigurationRoot configuracion = conf.GetConfiguration();
        private static string sbUriConsumoWebService = Environment.GetEnvironmentVariable("UriConsumoWebService001");
        private static string sbMetodoWsUriConsumowebService = Environment.GetEnvironmentVariable("MetodoWsUriConsumowebService001");
        private static string sbUriHomologacionDynamic = Environment.GetEnvironmentVariable("UriHomologacionDynamicSiac");
        private static string sbMetodoWsUriSiac = Environment.GetEnvironmentVariable("MetodoWsUriSiac");
        private static string sbMetodoWsUriAx = Environment.GetEnvironmentVariable("MetodoWsUriAx");
        private static string sbQueueResponse = Environment.GetEnvironmentVariable("QueueResponse");
        private static string sbConectionStringSend = Environment.GetEnvironmentVariable("ConectionStringResponse");

        [FunctionName("APICAJ018001")]
        public static async Task Run([ServiceBusTrigger("%QueueRequest%", Connection = "ConectionStringRequest")] string myQueueItem, ILogger log)
        {

            try
            {
                Logger.FileLogger("APICAJ018001", "Procesando Función");

                ResponseHomologacion respuesta = null;

                var APICAJ018001Request = JsonConvert.DeserializeObject<APICAJ018001MessageRequest>(myQueueItem);

                //Homologación
                string DataAreaId = APICAJ018001Request.DataAreaId;
                IManejadorHomologacion<ResponseHomologacion> _manejadorHomologacion = new ManejadorHomologacion<ResponseHomologacion>();

                respuesta = await _manejadorHomologacion.GetHomologacion(sbUriHomologacionDynamic, sbMetodoWsUriSiac, DataAreaId);
                // mapear resultado homologacion
                APICAJ018001Request.DataAreaId = respuesta?.Response ?? "000001";
                ////////////////////////////////////////////////////////////////

                //////////
                // ejecuta api
                ///
                string jsonData = JsonConvert.SerializeObject(APICAJ018001Request);
                ConsumoWebService<ResponseWS> cws = new ConsumoWebService<ResponseWS>();
                ResponseWS objResponse = cws.PostWebService(sbUriConsumoWebService, sbMetodoWsUriConsumowebService, jsonData);
                // mapear la clase response del metodo con respuesta del WS
                Logger.FileLogger("APICAJ018001", "Resultado:" + objResponse.DescripcionId);
                //
                APICAJ018001MessageResponse APICAJ018001Response = new APICAJ018001MessageResponse();
                string sesionid = APICAJ018001Request.SessionId.ToString();
                //
                sesionid = Guid.NewGuid().ToString(); // hasta mientras, se debe borrar
                //
                APICAJ018001Response.SessionId = sesionid;
                // falta mapeo resto de campos que responde WS

                IManejadorRequest<APICAJ018001MessageResponse> _manejadorRequest = new ManejadorRequest<APICAJ018001MessageResponse>();

                await _manejadorRequest.EnviarMensajeAsync(sesionid, sbConectionStringSend, sbQueueResponse, APICAJ018001Response);


            }
            catch (Exception ex)
            {
                Logger.FileLogger("APICAJ018001", ex.ToString());
            }

        }
    }
}
