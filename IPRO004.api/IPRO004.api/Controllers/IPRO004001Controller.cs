using Azure.Messaging.ServiceBus;
using IPRO004.api.Infraestructure.Configuration;
using IPRO004.api.Infraestructure.Services;
using IPRO004.Models;
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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IPRO004.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IPRO004001Controller : ControllerBase
    {
       
        private IManejadorRequest<APIPRO004001MessageRequest> QueueRequest;
        private IManejadorResponse<APIPRO004001MessageResponse> QueueResponse;
        private static RegistroLog Logger = new RegistroLog();
        private static readonly Configuracion conf = new Configuracion();
        static IConfigurationRoot configuracion = conf.GetConfiguration();
        private static string vl_ConnectionStringRequest = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringRequest").Value);
        private static string vl_ConnectionStringResponse = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringResponse").Value);
        private static string vl_QueueRequest = configuracion.GetSection("Data").GetSection("QueueRequest").Value.ToString();
        private static string vl_QueueResponse = configuracion.GetSection("Data").GetSection("QueueResponse").Value.ToString();
        private static int vl_Time = Convert.ToInt32(configuracion.GetSection("Data").GetSection("TimeSleep").Value);


        public IPRO004001Controller(IManejadorRequest<APIPRO004001MessageRequest> _manejadorRequest, IManejadorResponse<APIPRO004001MessageResponse> _manejadorReponse)
        {
            QueueRequest = _manejadorRequest;
            QueueResponse = _manejadorReponse;
        }


        [HttpPost]
        public async Task<ActionResult<APIPRO004001MessageResponse>> APIPRO004001(APIPRO004001MessageRequest parametrorequest)
        {
            try
            {
                APIPRO004001MessageResponse respuesta = null;
                string sesionid = Guid.NewGuid().ToString();
                parametrorequest.SesionId = sesionid;

                await QueueRequest.EnviarMensajeAsync(sesionid, vl_ConnectionStringRequest, vl_QueueRequest, parametrorequest);
                
                respuesta = await QueueResponse.RecibeMensajeSesion(vl_ConnectionStringResponse, vl_QueueResponse, sesionid, 1, 3);
               

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                Logger.FileLogger("APIPRO004001", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                
            }

        }

    }
}
