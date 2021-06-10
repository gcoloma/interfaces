using System;
using System.Threading.Tasks;
using Interface.Api.Infraestructura.Configuracion;
using IVTA007.Infraestructure.Configuration;
using IVTA007.Infraestructure.Services;
using IVTA007.Models;
using IVTA007.Models._002.Request;
using IVTA007.Models.Homologacion.ResponseHomologacion;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace IVTA007
{
    public static class IVTA007002
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

        [FunctionName("APIVTA007002")]
        public static async Task Run([ServiceBusTrigger("%QueueRequest002%", Connection = "ConectionStringRequest")] string myQueueItem, ILogger log)
        {

            try
            {

                Logger.FileLogger("APIVTA007002", "Procesando Función");
                

                ResponseHomologacion respuesta = null;

                var APIVTA007002Request = JsonConvert.DeserializeObject<APIVTA007002MessageRequest>(myQueueItem);
                               
                string jsonData = JsonConvert.SerializeObject(APIVTA007002Request);

                ConsumoWebService<ResponseWS> cws = new ConsumoWebService<ResponseWS>();
                ResponseWS objResponse = cws.PostWebService(sbUriConsumoWebService, sbMetodoWsUriConsumowebService, jsonData);

                Logger.FileLogger("APIVTA007002", "Resultado:" + objResponse.DescripcionId);
            }
            catch (Exception ex)
            {
                Logger.FileLogger("APIVTA007002", ex.ToString());
            }

        }
    }
}
