using Interface.Api.Infraestructura.Configuracion;
using Interface.Api.Infraestructura.Servicios;
using Interface.Api.Models.ICRE007002.Request;
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
    public class ICRE007002Controller : ControllerBase
    {
      
        private IManejadorRequestQueue<APICRE007002MessageRequestLegado> manejadorRequestQueue;
        private IManejadorResponseQueue2<APICRE007002MessageResponseLegado> manejadorReponseQueue;
        private static RegistroLog Logger = new RegistroLog();
        private static readonly Configuracion conf = new Configuracion();
        static IConfigurationRoot configuracion = conf.GetConfiguration();
        private static string sbConenctionStringEnvio = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringRequest").Value);
        private static string sbConenctionStringReceptar = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringResponse").Value);
        private static string nombrecolarequest = configuracion.GetSection("Data").GetSection("QueueRequest").Value.ToString();
        private static string nombrecolaresponse = configuracion.GetSection("Data").GetSection("QueueResponse").Value.ToString();
        private static int vl_Time = Convert.ToInt32(configuracion.GetSection("Data").GetSection("TimeSleep").Value);
        //
        // private readonly ILogger<ICRE007002Controller> _logger;
        //  const string nombrecolarequest = "apicre007002queuerequest";
        //  const string nombrecolaresponse = "apicre007002queueresponse";
        // const string nombrecolaresponse = "apicre007002queuerequest";
        // const string sbConenctionStringEnvio = "Endpoint=sb://crecoscorp.servicebus.windows.net/;SharedAccessKeyName=RootSendSharedAccessKey;SharedAccessKey=C9bdEuRdmxGd+TOGxSv3bS2fWVex1NKIUY91YdCvwb0=";
        //  const string sbConenctionStringReceptar =  "Endpoint=sb://crecoscorp.servicebus.windows.net/;SharedAccessKeyName=RootListenSharedAccessKey;SharedAccessKey=cHwMILbcjBXUFWQjugAV9GNT0+kqPiR3QFFxMXVGDmk=";
        // const string sbConenctionStringEnvio = "Endpoint=sb://busmia.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=kXi0LOPWXR9XlhO32aDvqAjy6DDoNJjrTBXi1i4nzW4=";
        // const string sbConenctionStringReceptar = "Endpoint=sb://busmia.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=kXi0LOPWXR9XlhO32aDvqAjy6DDoNJjrTBXi1i4nzW4=";


        public ICRE007002Controller(IManejadorRequestQueue<APICRE007002MessageRequestLegado> _manejadorRequestQueue
            , IManejadorResponseQueue2<APICRE007002MessageResponseLegado> _manejadorReponseQueue)
        {
           // _logger = logger;
            manejadorRequestQueue = _manejadorRequestQueue;
            manejadorReponseQueue = _manejadorReponseQueue;
        }
        [HttpPost]
        [Route("APICRE007002")]
        public async Task<ActionResult<APICRE007002MessageResponseLegado>> APICRE007002(APICRE007002MessageRequestLegado parametrorequest)
        {
            try
            {
                APICRE007002MessageResponseLegado respuesta = null;
                string sesionid = Guid.NewGuid().ToString();
                parametrorequest.SessionId = sesionid;
                await manejadorRequestQueue.EnviarMensajeAsync(sesionid, sbConenctionStringEnvio, nombrecolarequest, parametrorequest);

                respuesta = await manejadorReponseQueue.RecibeMensajeSesion(sbConenctionStringReceptar, nombrecolaresponse, sesionid, 1, 3);

                if (respuesta == null)
                {
                    Logger.FileLogger("APICRE007002", "No se retorno resultado de Dynamics");
                    return StatusCode(StatusCodes.Status204NoContent, "No se retorno resultado de dynamics");
                }
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                Logger.FileLogger("APICRE007002", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
          
            }

        }

    }
}
