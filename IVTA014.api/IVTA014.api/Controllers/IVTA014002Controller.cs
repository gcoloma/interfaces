using IVTA014.api.Infraestructura.Configuracion;
using IVTA014.api.Infraestructura.Servicios;
using IVTA014.api.Models._002.Request;
using IVTA014.api.Models._002.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IVTA014.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IVTA014002Controller : ControllerBase
    {

        private IManejadorRequestQueue<APIVTA014002MessageRequest> manejadorRequestQueue;
        private IManejadorResponseQueue2<APIVTA014002MessageResponse> manejadorReponseQueue;
        private static RegistroLog Logger = new RegistroLog();
        private static readonly Configuracion conf = new Configuracion();
        static IConfigurationRoot configuracion = conf.GetConfiguration();
        private static string Entorno = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToString();
        private static string sbConenctionStringEnvio = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringRequest002").Value);
        private static string sbConenctionStringReceptar = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringResponse002").Value);
        private static string nombrecolarequest = configuracion.GetSection("Data").GetSection("QueueRequest002").Value.ToString();
        private static string nombrecolaresponse = configuracion.GetSection("Data").GetSection("QueueResponse002").Value.ToString();
        private static int vl_Time = Convert.ToInt32(configuracion.GetSection("Data").GetSection("TimeSleep").Value);
        public IVTA014002Controller(IManejadorRequestQueue<APIVTA014002MessageRequest> _manejadorRequestQueue
            , IManejadorResponseQueue2<APIVTA014002MessageResponse> _manejadorReponseQueue)
        {
            manejadorRequestQueue = _manejadorRequestQueue;
            manejadorReponseQueue = _manejadorReponseQueue;
        }
        [HttpPost]
        [Route("APIVTA014001")]
        public async Task<ActionResult<APIVTA014002MessageResponse>> APICRE007001(APIVTA014002MessageRequest parametrorequest)
        {
            try
            {
                APIVTA014002MessageResponse respuesta = null;
                string sesionid = Guid.NewGuid().ToString();

                await manejadorRequestQueue.EnviarMensajeAsync(sesionid, sbConenctionStringEnvio, nombrecolarequest, parametrorequest);

                respuesta = await manejadorReponseQueue.RecibeMensajeSesion(sbConenctionStringReceptar, nombrecolaresponse, sesionid, 1, 3);

                if (respuesta == null)
                {
                    Logger.FileLogger("APIVTA014002", "No se retorno resultado de Dynamics");
                    return StatusCode(StatusCodes.Status204NoContent, "No se retorno resultado de dynamics");
                }
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                Logger.FileLogger("APIVTA014002", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }



    }
}
