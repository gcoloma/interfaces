using DSAC003.api.Infraestructure.Services;
using DSAC003.Api.Models.Request;
using DSAC003.Api.Models.Response;
using Interface.Api.Infraestructura.Configuracion;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace DSAC003.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DSAC003Controller : ControllerBase
    {

        private readonly ILogger<DSAC003Controller> _logger;
        private IManejadorRequest<APDSAC003001MessageRequest> QueueRequest;
        private IManejadorResponse<APDSAC003001MessageResponse> QueueResponse;

        private static RegistroLog Logger = new RegistroLog();
        private static readonly Configuracion conf = new Configuracion();

        static IConfigurationRoot configuracion = conf.GetConfiguration();

        private static string vl_ConnectionStringRequest = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringRequest").Value);
        private static string vl_ConnectionStringResponse = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringResponse").Value);
        private static string vl_QueueRequest = configuracion.GetSection("Data").GetSection("QueueRequest").Value.ToString();
        private static string vl_QueueResponse = configuracion.GetSection("Data").GetSection("QueueResponse").Value.ToString();
        private static int vl_Time = Convert.ToInt32(configuracion.GetSection("Data").GetSection("TimeSleep").Value);

        private static string vl_Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToString();

        public DSAC003Controller(ILogger<DSAC003Controller> logger, IManejadorRequest<APDSAC003001MessageRequest> _manejadorRequest, IManejadorResponse<APDSAC003001MessageResponse> _manejadorReponse)
        {
            _logger = logger;
            QueueRequest = _manejadorRequest;
            QueueResponse = _manejadorReponse;
        }


        [HttpGet]
        public IEnumerable<string> Get()
        {
            
            
            return new string[] {vl_Environment };
        }

        [HttpPost]
        public async Task<ActionResult<APDSAC003001MessageResponse>> DSAC003(APDSAC003001MessageRequest parametrorequest)
        {
            try
            {
                APDSAC003001MessageResponse respuesta = null;
                string sesionid = Guid.NewGuid().ToString();
                parametrorequest.SesionId = sesionid;
                parametrorequest.Environment = vl_Environment;
                await QueueRequest.EnviarMensajeAsync(sesionid, vl_ConnectionStringRequest, vl_QueueRequest, parametrorequest);

                respuesta = await QueueResponse.RecibeMensajeSesion(vl_ConnectionStringResponse, vl_QueueResponse, sesionid, 1, 3);

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                Logger.FileLogger("APIDSAC003", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }

    }
}