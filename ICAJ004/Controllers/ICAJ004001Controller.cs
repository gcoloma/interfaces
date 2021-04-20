using ICAJ004.Infrastructure.Configuration;
using ICAJ004.Infrastructure.Services;
using ICAJ004.Models.Request;
using ICAJ004.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ004.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ICAJ004001Controller : ControllerBase
    {
        private IManejadorRequest<APICAJ004001MessageRequest> QueueRequest;
        private IManejadorResponse<APICAJ004001MessageResponse> QueueResponse;
        private static RegistroLog Logger = new RegistroLog();
        private static readonly Configuracion conf = new Configuracion();
        static IConfigurationRoot configuracion = conf.GetConfiguration();
        private static string vl_ConnectionStringRequest = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringRequest").Value.ToString());
        private static string vl_ConnectionStringResponse = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringResponse").Value.ToString());
        private static string vl_QueueRequest = configuracion.GetSection("Data").GetSection("QueueRequest").Value.ToString();
        private static string vl_QueueResponse = configuracion.GetSection("Data").GetSection("QueueResponse").Value.ToString();
        private static int vl_Time = Convert.ToInt32(configuracion.GetSection("Data").GetSection("TimeSleep").Value);
        private static string vl_Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToString();


        public ICAJ004001Controller(IManejadorRequest<APICAJ004001MessageRequest> _manejadorRequest, IManejadorResponse<APICAJ004001MessageResponse> _manejadorReponse)
        {
            QueueRequest = _manejadorRequest;
            QueueResponse = _manejadorReponse;
        }




        

        [HttpPost]
        public async Task<ActionResult<APICAJ004001MessageResponse>> ICAJ004001(APICAJ004001MessageRequest parametrorequest)
        {
            try
            {
                APICAJ004001MessageResponse respuesta = null;
                string sesionid = Guid.NewGuid().ToString();

                parametrorequest.SessionId = sesionid;
                parametrorequest.Enviroment = vl_Environment;

                await QueueRequest.EnviarMensajeAsync(sesionid, vl_ConnectionStringRequest, vl_QueueRequest, parametrorequest);

                respuesta = await QueueResponse.RecibeMensajeSesion(vl_ConnectionStringResponse, vl_QueueResponse, sesionid, 1, 3);
                if (respuesta == null)
                {
                    Logger.FileLogger("ICAJ004001", "No se retorno resultado de Dynamics");
                    return StatusCode(StatusCodes.Status204NoContent, "No se retorno resultado de dynamics");
                }

                return Ok(parametrorequest.SessionId);
            }
            catch (Exception ex)
            {
                Logger.FileLogger("ICAJ004001", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }
    }
}
