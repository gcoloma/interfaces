using ICXP003.api.Infraestructure.Configuration;
using ICXP003.api.Infraestructure.Services;
using ICXP003.api.Models._001.Request;
using ICXP003.api.Models._001.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ICXP003.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ICXP003001Controller : ControllerBase
    {
        private IManejadorRequest<APICXP003001MessageRequest> QueueRequest;
        private IManejadorResponse<APICXP003001MessageResponse> QueueResponse;
        private static RegistroLog Logger = new RegistroLog();
        private static readonly Configuracion conf = new Configuracion();
        static IConfigurationRoot configuracion = conf.GetConfiguration();
        private static string vl_ConnectionStringRequest = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringRequest").Value);
        private static string vl_ConnectionStringResponse = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringResponse").Value);
        private static string vl_QueueRequest = configuracion.GetSection("Data").GetSection("QueueRequest").Value.ToString();
        private static string vl_QueueResponse = configuracion.GetSection("Data").GetSection("QueueResponse").Value.ToString();
        private static int vl_Time = Convert.ToInt32(configuracion.GetSection("Data").GetSection("TimeSleep").Value);


        public ICXP003001Controller(IManejadorRequest<APICXP003001MessageRequest> _manejadorRequest, IManejadorResponse<APICXP003001MessageResponse> _manejadorReponse)
        {
            QueueRequest = _manejadorRequest;
            QueueResponse = _manejadorReponse;
        }

        
        [HttpPost]
        
        public async Task<ActionResult<APICXP003001MessageResponse>> APICXP003001(APICXP003001MessageRequest parametrorequest)
        {
            try
            {
                APICXP003001MessageResponse respuesta = null;
                string sesionid = Guid.NewGuid().ToString();
                parametrorequest.SesionId = sesionid;

                await QueueRequest.EnviarMensajeAsync(sesionid, vl_ConnectionStringRequest, vl_QueueRequest, parametrorequest);

                respuesta = await QueueResponse.RecibeMensajeSesion(vl_ConnectionStringResponse, vl_QueueResponse, sesionid, 1, 3);

                if (respuesta == null)
                {
                    Logger.FileLogger("APICXP003001", "No se retorno resultado de Dynamics");
                    return StatusCode(StatusCodes.Status204NoContent, "No se retorno resultado de dynamics");
                }

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                Logger.FileLogger("APICXP003001", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }

    }
}
