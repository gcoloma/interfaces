using ICAJ024.Infraestructure.Configuration;
using ICAJ024.Infraestructure.Services;
using ICAJ024.Models._001.Request;
using ICAJ024.Models._001.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ICAJ024001Controller : ControllerBase
    {
        private IManejadorRequest<APICAJ024001MessageRequest> QueueRequest;
        private IManejadorResponse<APILOG002001MessageResponse> QueueResponse;
        private static RegistroLog Logger = new RegistroLog();
        private static readonly Configuracion conf = new Configuracion();
        static IConfigurationRoot configuracion = conf.GetConfiguration();
        private static string vl_ConnectionStringRequest = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringRequest").Value);
        private static string vl_ConnectionStringResponse = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringResponse").Value);
        private static string vl_QueueRequest = configuracion.GetSection("Data").GetSection("QueueRequest").Value.ToString();
        private static string vl_QueueResponse = configuracion.GetSection("Data").GetSection("QueueResponse").Value.ToString();
        private static int vl_Time = Convert.ToInt32(configuracion.GetSection("Data").GetSection("TimeSleep").Value);
        private static string vl_Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToString();


        public ICAJ024001Controller(IManejadorRequest<APICAJ024001MessageRequest> _manejadorRequest, IManejadorResponse<APILOG002001MessageResponse> _manejadorReponse)
        {
            QueueRequest = _manejadorRequest;
            QueueResponse = _manejadorReponse;
        }
        

       [HttpPost]
       [Route("ICAJ024001")]
        public async Task<ActionResult<APILOG002001MessageResponse>> ICAJ024001(APICAJ024001MessageRequest parametrorequest)
        {
            try
            {
                APILOG002001MessageResponse respuesta = null;
                string sesionid = Guid.NewGuid().ToString();
                parametrorequest.SessionId = sesionid;
                parametrorequest.Enviroment = vl_Environment;

                await QueueRequest.EnviarMensajeAsync(sesionid, vl_ConnectionStringRequest, vl_QueueRequest, parametrorequest);

                respuesta = await QueueResponse.RecibeMensajeSesion(vl_ConnectionStringResponse, vl_QueueResponse, sesionid, 1, 3);

                if (respuesta == null)
                {
                    Logger.FileLogger("ICAJ024001", "No se retorno resultado de Dynamics");
                    return StatusCode(StatusCodes.Status204NoContent, "No se retorno resultado de dynamics");
                }

                return Ok("Proceso completado");
            }
            catch (Exception ex)
            {
                Logger.FileLogger("ICAJ024001", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }
    }
}
