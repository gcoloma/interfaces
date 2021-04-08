using Azure.Messaging.ServiceBus;
using ICRE001.api.Infraestructure.Configuration;
using ICRE001.api.Infraestructure.Services;
using ICRE001.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ICRE001.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ICRE001002Controller : ControllerBase
    {
        private IManejadorRequest<APICRE001002MessageRequest> QueueRequest;
        private IManejadorResponse<APICRE001002MessageResponse> QueueResponse;
        private static RegistroLog Logger = new RegistroLog();
        private static readonly Configuracion conf = new Configuracion();
        static IConfigurationRoot configuracion = conf.GetConfiguration();
        private static string vl_ConnectionStringRequest = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringRequest").Value);
        private static string vl_ConnectionStringResponse = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringResponse").Value);
        private static string vl_QueueRequest = configuracion.GetSection("Data").GetSection("QueueRequest").Value.ToString();
        private static string vl_QueueResponse = configuracion.GetSection("Data").GetSection("QueueResponse").Value.ToString();
        private static int vl_Time = Convert.ToInt32(configuracion.GetSection("Data").GetSection("TimeSleep").Value);


        public ICRE001002Controller(IManejadorRequest<APICRE001002MessageRequest> _manejadorRequest, IManejadorResponse<APICRE001002MessageResponse> _manejadorReponse)
        {
           QueueRequest = _manejadorRequest;
           QueueResponse = _manejadorReponse;
        }




        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public async Task<ActionResult<APICRE001002MessageResponse>> ICRE001002(APICRE001002MessageRequest parametrorequest)
        {
            try
            {
                APICRE001002MessageResponse respuesta = null;
                string sesionid = Guid.NewGuid().ToString();
                parametrorequest.SesionId = sesionid;

                await QueueRequest.EnviarMensajeAsync(sesionid, vl_ConnectionStringRequest, vl_QueueRequest, parametrorequest);

                respuesta = await QueueResponse.RecibeMensajeSesion(vl_ConnectionStringResponse, vl_QueueResponse, sesionid, 1, 3);


                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                Logger.FileLogger("APICRE001002", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }

    }
}
