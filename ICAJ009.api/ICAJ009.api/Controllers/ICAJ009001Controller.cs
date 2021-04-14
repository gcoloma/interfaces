using ICAJ009.api.Infraestructura.Configuracion;
using ICAJ009.api.Infraestructura.Servicios;
using ICAJ009.api.Models._001.Request;
using ICAJ009.api.Models._001.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ICAJ009.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ICAJ009001Controller : ControllerBase
    {

        private IManejadorRequestQueue<APICAJ009001MessageRequest> manejadorRequestQueue;
        private IManejadorResponseQueue2<APICAJ009001MessageResponse> manejadorReponseQueue;
        private static RegistroLog Logger = new RegistroLog();
        private static readonly Configuracion conf = new Configuracion();
        static IConfigurationRoot configuracion = conf.GetConfiguration();
        private static string Entorno = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToString();
        private static string sbConenctionStringEnvio = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringRequest001").Value);
        private static string sbConenctionStringReceptar = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringResponse001").Value);
        private static string nombrecolarequest = configuracion.GetSection("Data").GetSection("QueueRequest001").Value.ToString();
        private static string nombrecolaresponse = configuracion.GetSection("Data").GetSection("QueueResponse001").Value.ToString();
        private static int vl_Time = Convert.ToInt32(configuracion.GetSection("Data").GetSection("TimeSleep").Value);
        public ICAJ009001Controller(IManejadorRequestQueue<APICAJ009001MessageRequest> _manejadorRequestQueue
            , IManejadorResponseQueue2<APICAJ009001MessageResponse> _manejadorReponseQueue)
        {
            manejadorRequestQueue = _manejadorRequestQueue;
            manejadorReponseQueue = _manejadorReponseQueue;
        }
        [HttpPost]
        [Route("APICAJ009001")]
        public async Task<ActionResult<APICAJ009001MessageResponse>> APICRE007001(APICAJ009001MessageRequest parametrorequest)
        {
            try
            {
                APICAJ009001MessageResponse respuesta = null;
                string sesionid = Guid.NewGuid().ToString();

                await manejadorRequestQueue.EnviarMensajeAsync(sesionid, sbConenctionStringEnvio, nombrecolarequest, parametrorequest);

                respuesta = await manejadorReponseQueue.RecibeMensajeSesion(sbConenctionStringReceptar, nombrecolaresponse, sesionid, 1, 3);

                if (respuesta == null)
                {
                    Logger.FileLogger("APICAJ009001", "No se retorno resultado de Dynamics");
                    return StatusCode(StatusCodes.Status204NoContent, "No se retorno resultado de dynamics");
                }
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                Logger.FileLogger("APICAJ009001", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }



    }
}
