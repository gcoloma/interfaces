using ICAJ011.Infraestructura.Configuracion;
using ICAJ011.Infraestructura.Servicios;
using ICAJ011.Models;
using ICAJ011.Models._001.Request;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICAJ011.Function
{
    public static class ICAJ011001
    {
        
            private static RegistroLog Logger = new RegistroLog();
            private static readonly Configuracion conf = new Configuracion();
            static IConfigurationRoot configuracion = conf.GetConfiguration();
            private static string sbUriConsumoWebService = Environment.GetEnvironmentVariable("UriConsumoWebService");
            private static string sbMetodoWsUriConsumowebService = Environment.GetEnvironmentVariable("MetodoWsUriConsumowebService");

            [FunctionName("ICAJ011001")]
            public static async Task Run([ServiceBusTrigger("%QueueRequest001%", Connection = "ConectionStringRequest001")] string myQueueItem, ILogger log)
            {

                try
                {

                    Logger.FileLogger("ICAJ011001", "Procesando Función");
                    var APICAJ011001Request = JsonConvert.DeserializeObject<APICAJ011001MessageRequest>(myQueueItem);

                    string jsonData = JsonConvert.SerializeObject(APICAJ011001Request);

                    ConsumoWebService<ResponseWS> cws = new ConsumoWebService<ResponseWS>();
                    ResponseWS objResponse = cws.PostWebService(sbUriConsumoWebService, sbMetodoWsUriConsumowebService, jsonData);

                        Logger.FileLogger("ICAJ011001", "Resultado:" + objResponse.DescripcionId);
                }
                catch (Exception ex)
                {
                    Logger.FileLogger("ICAJ011001", ex.ToString());
                }

            }
     }
}
