using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Interface.Api.Infraestructura.Configuracion;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FNC_ICXP003
{
    public static class Interface_Function
    {
        private static RegistroLog Logger = new RegistroLog();
        private static readonly Configuracion conf = new Configuracion();
        static IConfigurationRoot configuracion = conf.GetConfiguration();
        private static string vl_ConnectionStringRequest = Convert.ToString(configuracion.GetSection("Values").GetSection("ConectionStringRequest").Value);

        private static string vl_ConnectionStringResponse = Convert.ToString(configuracion.GetSection("Values").GetSection("ConectionStringResponse").Value);

        private static string vl_QueueResponse = Convert.ToString(configuracion.GetSection("Values").GetSection("Queue-Response").Value);

        [FunctionName("Interface_Function")]
        public static async Task Run([ServiceBusTrigger("%Queue-Request%", Connection = "ConectionStringRequest")] string myQueueItem, ILogger log)
        {
            try
            {
                await using (ServiceBusClient client = new ServiceBusClient(vl_ConnectionStringResponse))
                {

                    ServiceBusSender sender = client.CreateSender(vl_QueueResponse);
                    ServiceBusMessage message = new ServiceBusMessage(myQueueItem);

                    await sender.SendMessageAsync(message);

                }
            }
            catch (Exception ex)
            {
                Logger.FileLogger("Interface_Function", ex.ToString());
            }

        }
    }

}
