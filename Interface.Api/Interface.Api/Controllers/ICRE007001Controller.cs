using Interface.Api.Infraestructura.Configuracion;
using Interface.Api.Infraestructura.Servicios;
using Interface.Api.Models.ICRE007001.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Interface.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ICRE007001Controller : ControllerBase
    {
     
        private IManejadorRequestQueue<APICRE007001MessageRequestLegado> manejadorRequestQueue;
        private IManejadorResponseQueue2<APICRE007001MessageResponseLegado> manejadorReponseQueue;
        private static RegistroLog Logger = new RegistroLog();
        private static readonly Configuracion conf = new Configuracion();
        static IConfigurationRoot configuracion = conf.GetConfiguration();
        private static string sbConenctionStringEnvio = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringRequest").Value);
        private static string sbConenctionStringReceptar = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringResponse").Value);
        private static string nombrecolarequest = configuracion.GetSection("Data").GetSection("QueueRequest").Value.ToString();
        private static string nombrecolaresponse = configuracion.GetSection("Data").GetSection("QueueResponse").Value.ToString();
        private static int vl_Time = Convert.ToInt32(configuracion.GetSection("Data").GetSection("TimeSleep").Value);
        public ICRE007001Controller(ILogger<ICRE007001Controller> logger
            , IManejadorRequestQueue<APICRE007001MessageRequestLegado> _manejadorRequestQueue
            , IManejadorResponseQueue2<APICRE007001MessageResponseLegado> _manejadorReponseQueue)
        {
           
            manejadorRequestQueue = _manejadorRequestQueue;
            manejadorReponseQueue = _manejadorReponseQueue;
        }
        [HttpPost]
        [Route("APICRE007001")]
        public async Task<ActionResult<APICRE007001MessageResponseLegado>> APICRE007001(APICRE007001MessageRequestLegado parametrorequest)
        {
            try
            {
                APICRE007001MessageResponseLegado respuesta = null;
                string sesionid = Guid.NewGuid().ToString();

                await manejadorRequestQueue.EnviarMensajeAsync(sesionid, sbConenctionStringEnvio, nombrecolarequest, parametrorequest);

                respuesta = await manejadorReponseQueue.RecibeMensajeSesion(sbConenctionStringReceptar, nombrecolaresponse, sesionid, 1, 3);

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }



    }
}
