using IVTA004.Infrastructure.Configuration;
using IVTA004.Infrastructure.Services;
using IVTA004.Models._001.Request;
using IVTA004.Models._001.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVTA004.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IVTA004001Controller : ControllerBase
    {
        private IManejadorRequest<APISAC020001MessageRequest> QueueRequest;
        private IManejadorResponse<APIVTA004001MessageResponse> QueueResponse;
        private static RegistroLog Logger = new RegistroLog();
        private static readonly Configuracion conf = new Configuracion();
        static IConfigurationRoot configuracion = conf.GetConfiguration();
        private static string vl_ConnectionStringRequest = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringRequest").Value.ToString());
        private static string vl_ConnectionStringResponse = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringResponse").Value.ToString());
        private static string vl_QueueRequest = configuracion.GetSection("Data").GetSection("QueueRequest").Value.ToString();
        private static string vl_QueueResponse = configuracion.GetSection("Data").GetSection("QueueResponse").Value.ToString();
        private static int vl_Time = Convert.ToInt32(configuracion.GetSection("Data").GetSection("TimeSleep").Value);
        private static string vl_Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToString();


        public IVTA004001Controller(IManejadorRequest<APISAC020001MessageRequest> _manejadorRequest, IManejadorResponse<APIVTA004001MessageResponse> _manejadorReponse)
        {
            QueueRequest = _manejadorRequest;
            QueueResponse = _manejadorReponse;
        }





        [HttpPost]
        [Route("IVTA004001")]
        public async Task<ActionResult<APIVTA004001MessageResponse>> IVTA004001(APISAC020001MessageRequest parametrorequest)
        {
            try
            {
                APIVTA004001MessageResponse respuesta = null;
                string sesionid = Guid.NewGuid().ToString();

                parametrorequest.SessionId = sesionid;
                parametrorequest.Enviroment = vl_Environment;

                await QueueRequest.EnviarMensajeAsync(sesionid, vl_ConnectionStringRequest, vl_QueueRequest, parametrorequest);

                respuesta = await QueueResponse.RecibeMensajeSesion(vl_ConnectionStringResponse, vl_QueueResponse, sesionid, 1, 3);
                if (respuesta == null)
                {
                    Logger.FileLogger("IVTA004001", "No se retorno resultado de Dynamics");
                    return StatusCode(StatusCodes.Status204NoContent, "No se retorno resultado de dynamics");
                }

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                Logger.FileLogger("IVTA004001", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }
    }
}

