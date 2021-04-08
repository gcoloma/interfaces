using System;
using System.Threading.Tasks;
using ISAC018.Infraestructura;
using ISAC018.Models._001.Resquest;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ISAC018
{
    public static class APISAC018001
    {
       
        public static string sbConenctionStringReceptar = Environment.GetEnvironmentVariable("ConectionStringRequest001");
        private static string nombrecolarequest = Environment.GetEnvironmentVariable("QueueRequest001");
        private static string nombrecolaresponse = Environment.GetEnvironmentVariable("QueueResponse001");
        private static string sbConenctionStringEnvio = Environment.GetEnvironmentVariable("ConectionStringResponse001");

        [FunctionName("APISAC018001")]
        public static async Task Run([ServiceBusTrigger("%QueueRequest001%", Connection = "ConectionStringRequest001")]string myQueueItem, ILogger log)
        {
            try
            {
                log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            var APISAC018001Request = JsonConvert.DeserializeObject<APISAC018001MessageRequest>(myQueueItem);

            //////////
            // ejecuta api
            ////////
            ///
            }
            catch (Exception ex)
            {
                log.LogError($"Exception ISAC018001: {ex.Message}");
            }

}
    }
}
