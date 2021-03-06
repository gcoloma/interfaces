using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE004.api.Infraestructure.Services
{
    public interface IManejadorResponse<T>
    {
        Task<T> RecibeMensajeSesion(string cadenaConexion, string nombreCola, string sesionId, int segundos, int intentos);
    }
    public class ManejadorResponse<T> : IManejadorResponse<T>
    {
        public async Task<T> RecibeMensajeSesion(string cadenaConexion, string nombreCola, string sesionId, int segundos, int intentos)
        {
            int contador = 0;
            T respuesta = default(T);
            var serviceBusConnectionStringBuilder = new ServiceBusConnectionStringBuilder(cadenaConexion);

            var serviceBusConnection = new ServiceBusConnection(serviceBusConnectionStringBuilder);

            var sessionClient = new SessionClient(serviceBusConnection, nombreCola, ReceiveMode.PeekLock, null, 0);

            var messageSession = await sessionClient.AcceptMessageSessionAsync(sesionId, TimeSpan.FromMinutes(1));

            if (messageSession != null)
            {
                while (contador < intentos)
                {
                    Message message = await messageSession.ReceiveAsync(TimeSpan.FromSeconds(5));

                    if (message != null)
                    {
                        var bodyText = System.Text.Encoding.UTF8.GetString(message.Body);
                        respuesta = JsonConvert.DeserializeObject<T>(bodyText);

                        await messageSession.CompleteAsync(message.SystemProperties.LockToken);
                        contador = intentos;
                    }
                    else
                    {
                        await Task.Delay(segundos * 1000);
                    }
                    contador++;
                }
            }
            await messageSession.CloseAsync();
            await sessionClient.CloseAsync();
            await serviceBusConnection.CloseAsync();

            return respuesta;
        }
    }

}
