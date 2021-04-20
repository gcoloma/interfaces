using ICAJ005.Infrastructure.Configuration;
using ICAJ005.Infrastructure.Services;
using ICAJ005.Models._001.Request;
using ICAJ005.Models._001.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ005.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ICAJ005001Controller : ControllerBase
    {
        private IManejadorRequest<APICAJ005001MessageRequest> QueueRequest;
        private IManejadorResponse<APICAJ005001MessageResponse> QueueResponse;
        private static RegistroLog Logger = new RegistroLog();
        private static readonly Configuracion conf = new Configuracion();
        static IConfigurationRoot configuracion = conf.GetConfiguration();
        private static string vl_ConnectionStringRequest = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringRequest").Value.ToString());
        private static string vl_ConnectionStringResponse = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringResponse").Value.ToString());
        private static string vl_QueueRequest = configuracion.GetSection("Data").GetSection("QueueRequest").Value.ToString();
        private static string vl_QueueResponse = configuracion.GetSection("Data").GetSection("QueueResponse").Value.ToString();
        private static int vl_Time = Convert.ToInt32(configuracion.GetSection("Data").GetSection("TimeSleep").Value);
        private static string vl_Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToString();


        public ICAJ005001Controller(IManejadorRequest<APICAJ005001MessageRequest> _manejadorRequest, IManejadorResponse<APICAJ005001MessageResponse> _manejadorReponse)
        {
            QueueRequest = _manejadorRequest;
            QueueResponse = _manejadorReponse;
        }




        

        [HttpPost]
        [Route("ICAJ005001")]
        public async Task<ActionResult<APICAJ005001MessageResponse>> ICAJ005001(APICAJ005001MessageRequest parametrorequest)
        {
            try
            {
                APICAJ005001MessageResponse respuesta = null;
                string sesionid = Guid.NewGuid().ToString();

                parametrorequest.SessionId = sesionid;
                parametrorequest.Enviroment = vl_Environment;

                await QueueRequest.EnviarMensajeAsync(sesionid, vl_ConnectionStringRequest, vl_QueueRequest, parametrorequest);

                respuesta = await QueueResponse.RecibeMensajeSesion(vl_ConnectionStringResponse, vl_QueueResponse, sesionid, 1, 3);
                if (respuesta == null)
                {
                    Logger.FileLogger("ICAJ005001", "No se retorno resultado de Dynamics");
                    return StatusCode(StatusCodes.Status204NoContent, "No se retorno resultado de dynamics");
                }

                return Ok(parametrorequest.SessionId);
            }
            catch (Exception ex)
            {
                Logger.FileLogger("ICAJ005001", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }
    }
}
