using System;
using System.Threading.Tasks;


using ISAC017.Infraestructura.Configuracion;
using ISAC017.Infraestructura.Servicios;
using ISAC017.Models;
using ISAC017.Models._003.Request;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ISAC017.Function
{
    public static class ISAC017003
    {
        private static RegistroLog Logger = new RegistroLog();
        private static readonly Configuracion conf = new Configuracion();
        static IConfigurationRoot configuracion = conf.GetConfiguration();
        private static string sbUriConsumoWebService = Environment.GetEnvironmentVariable("UriConsumoWebService");
        private static string sbMetodoWsUriConsumowebService = Environment.GetEnvironmentVariable("MetodoWsUriConsumowebService");

        [FunctionName("APISAC017003")]
        public static async Task Run([ServiceBusTrigger("%QueueRequest001%", Connection = "ConectionStringRequest001")] string myQueueItem, ILogger log)
        {

            try
            {

                Logger.FileLogger("APISAC017003", "Procesando Función");
                var APISAC020002Request = JsonConvert.DeserializeObject<APISAC017003MessageRequest>(myQueueItem);

                string jsonData = JsonConvert.SerializeObject(APISAC020002Request);

                ConsumoWebService<ResponseWS> cws = new ConsumoWebService<ResponseWS>();
                ResponseWS objResponse = cws.PostWebService(sbUriConsumoWebService, sbMetodoWsUriConsumowebService, jsonData);

                Logger.FileLogger("APISAC017003", "Resultado:" + objResponse.DescripcionId);
            }
            catch (Exception ex)
            {
                Logger.FileLogger("APISAC017003", ex.ToString());
            }

        }
    }
}
