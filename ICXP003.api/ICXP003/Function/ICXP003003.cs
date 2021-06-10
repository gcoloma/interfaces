using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using ICXP003.Infraestructura.Servicios;
using ICXP003.Models;
using ICXP003.Models.Request;
using Interface.Api.Infraestructura.Configuracion;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ICXP003
{
    public static class ICXP003003
    {
        private static RegistroLog Logger = new RegistroLog();
        private static readonly Configuracion conf = new Configuracion();
        static IConfigurationRoot configuracion = conf.GetConfiguration();
        private static string sbUriConsumoWebService = Environment.GetEnvironmentVariable("UriConsumoWebService");
        private static string sbMetodoWsUriConsumowebService = Environment.GetEnvironmentVariable("MetodoWsUriConsumowebService");

        [FunctionName("APICXP003003")]
        public static async Task Run([ServiceBusTrigger("%QueueRequest001%", Connection = "ConectionStringRequest001")] string myQueueItem, ILogger log)
        {

            try
            {

                Logger.FileLogger("APICXP003003", "Procesando Función");
                var APICXP003003Request = JsonConvert.DeserializeObject<APICXP003003MessageRequest>(myQueueItem);

                string jsonData = JsonConvert.SerializeObject(APICXP003003Request);

                ConsumoWebService<ResponseWS> cws = new ConsumoWebService<ResponseWS>();
                ResponseWS objResponse = cws.PostWebService(sbUriConsumoWebService, sbMetodoWsUriConsumowebService, jsonData);

                Logger.FileLogger("APICXP003003", "Resultado:" + objResponse.DescripcionId);
            }
            catch (Exception ex)
            {
                Logger.FileLogger("APICXP003003", ex.ToString());
            }

        }
    
    }
}
