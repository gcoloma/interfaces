using ICRE006.Infraestructure.Configuration;
using ICRE006.Infraestructure.Services;
using ICRE006.Models._001.Request;
using ICRE006.Models._001.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE006.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ICRE006001Controller : ControllerBase
    {
        private IManejadorRequest<APICRE006001MessageRequest> QueueRequest;
        private IManejadorResponse<APICRE006001MessageResponse> QueueResponse;
        private static RegistroLog Logger = new RegistroLog();
        private static readonly Configuracion conf = new Configuracion();
        static IConfigurationRoot configuracion = conf.GetConfiguration();
        private static string vl_ConnectionStringRequest = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringRequest").Value);
        private static string vl_ConnectionStringResponse = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringResponse").Value);
        private static string vl_QueueRequest = configuracion.GetSection("Data").GetSection("QueueRequest").Value.ToString();
        private static string vl_QueueResponse = configuracion.GetSection("Data").GetSection("QueueResponse").Value.ToString();
        private static int vl_Time = Convert.ToInt32(configuracion.GetSection("Data").GetSection("TimeSleep").Value);
        private static string vl_Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToString();


        public ICRE006001Controller(IManejadorRequest<APICRE006001MessageRequest> _manejadorRequest, IManejadorResponse<APICRE006001MessageResponse> _manejadorReponse)
        {
            QueueRequest = _manejadorRequest;
            QueueResponse = _manejadorReponse;
        }


        [HttpPost]
        [Route("ICRE006001")]
        public async Task<ActionResult<APICRE006001MessageResponse>> ICRE006001(APICRE006001MessageRequest parametrorequest)
        {
            try
            {
                APICRE006001MessageResponse respuesta = null;
                string sesionid = Guid.NewGuid().ToString();
                parametrorequest.SesionId = sesionid;
                parametrorequest.Enviroment = vl_Environment;

                await QueueRequest.EnviarMensajeAsync(sesionid, vl_ConnectionStringRequest, vl_QueueRequest, parametrorequest);

                respuesta = await QueueResponse.RecibeMensajeSesion(vl_ConnectionStringResponse, vl_QueueResponse, sesionid, 1, 3);

                if (respuesta == null)
                {
                    Logger.FileLogger("ICRE006001", "No se retorno resultado de Dynamics");
                    return StatusCode(StatusCodes.Status204NoContent, "No se retorno resultado de dynamics");
                }

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                Logger.FileLogger("ICRE006001", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }
    }
}
