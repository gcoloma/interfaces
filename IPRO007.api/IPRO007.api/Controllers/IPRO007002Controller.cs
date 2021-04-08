using IPRO007.api.Infraestructura.Configuracion;
using IPRO007.api.Infraestructura.Servicios;
using IPRO007.api.Models._002.Request;
using IPRO007.api.Models._002.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IPRO007.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IPRO007002Controller : ControllerBase
    {
        private IManejadorRequestQueue<APIPRO007002MessageRequestLegado> manejadorRequestQueue;
        private IManejadorResponseQueue2<APIPRO007002MessageResponseLegado> manejadorReponseQueue;
        private static RegistroLog Logger = new RegistroLog();
        private static readonly Configuracion conf = new Configuracion();
        static IConfigurationRoot configuracion = conf.GetConfiguration();
        private static string Entorno = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToString();
        private static string sbConenctionStringEnvio = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringRequest").Value);
        private static string sbConenctionStringReceptar = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringResponse").Value);
        private static string nombrecolarequest = configuracion.GetSection("Data").GetSection("QueueRequest").Value.ToString();
        private static string nombrecolaresponse = configuracion.GetSection("Data").GetSection("QueueResponse").Value.ToString();
        private static int vl_Time = Convert.ToInt32(configuracion.GetSection("Data").GetSection("TimeSleep").Value);


        public IPRO007002Controller(IManejadorRequestQueue<APIPRO007002MessageRequestLegado> _manejadorRequestQueue
            , IManejadorResponseQueue2<APIPRO007002MessageResponseLegado> _manejadorReponseQueue)
        {
            // _logger = logger;
            manejadorRequestQueue = _manejadorRequestQueue;
            manejadorReponseQueue = _manejadorReponseQueue;
        }
        [HttpPost]
        [Route("METHODAPIPRO007002")]
        public async Task<ActionResult<APIPRO007002MessageResponseLegado>> APIPRO007002(APIPRO007002MessageRequestLegado parametrorequest)
        {
            try
            {
                APIPRO007002MessageResponseLegado respuesta = null;
                string sesionid = Guid.NewGuid().ToString();
                parametrorequest.SessionId = sesionid;
                await manejadorRequestQueue.EnviarMensajeAsync(sesionid, sbConenctionStringEnvio, nombrecolarequest, parametrorequest);

                respuesta = await manejadorReponseQueue.RecibeMensajeSesion(sbConenctionStringReceptar, nombrecolaresponse, sesionid, 1, 3);

                if (respuesta == null)
                {
                    Logger.FileLogger("APIPRO007002", "No se retorno resultado de Dynamics");
                    return StatusCode(StatusCodes.Status204NoContent, "No se retorno resultado de dynamics");
                }
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                Logger.FileLogger("APIPRO007002", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }
    }
}
