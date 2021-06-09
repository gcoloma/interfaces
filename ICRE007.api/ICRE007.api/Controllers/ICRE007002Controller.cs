using ICRE007.api.Infraestructura.Configuracion;
using ICRE007.api.Infraestructura.Servicios;
using ICRE007.api.Models._002.Request;
using ICRE007.api.Models._002.Response;
using ICRE007.api.Models.Homologa;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ICRE007.api.Controllers
{
    //[Route("[controller]")]
    [ApiController]
    public class ICRE007002Controller : ControllerBase
    {

        private IManejadorRequestQueue<APICRE007002MessageRequest> manejadorRequestQueue;
        private IManejadorResponseQueue2<APICRE007002MessageResponse> manejadorReponseQueue;
        private IHomologacionService<ResponseHomologa> homologacionRequest;
        private static RegistroLog Logger = new RegistroLog();
        private static readonly Configuracion conf = new Configuracion();
        static IConfigurationRoot configuracion = conf.GetConfiguration();
        private static string Entorno = Convert.ToString(configuracion.GetSection("Data").GetSection("ASPNETCORE_ENVIRONMENT").Value);
        private static string sbUriHomologacionDynamic = Convert.ToString(configuracion.GetSection("Data").GetSection("UriHomologacionDynamicSiac").Value);
        private static string sbMetodoWsUriSiac = Convert.ToString(configuracion.GetSection("Data").GetSection("MetodoWsUriSiac").Value);
        private static string sbMetodoWsUriAx = Convert.ToString(configuracion.GetSection("Data").GetSection("MetodoWsUriAx").Value);
        private static string sbConenctionStringEnvio = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringRequest002").Value);
        private static string sbConenctionStringReceptar = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringResponse002").Value);
        private static string nombrecolarequest = configuracion.GetSection("Data").GetSection("QueueRequest002").Value.ToString();
        private static string nombrecolaresponse = configuracion.GetSection("Data").GetSection("QueueResponse002").Value.ToString();
        private static int vl_Time = Convert.ToInt32(configuracion.GetSection("Data").GetSection("TimeSleep").Value);
        string respuestaLog;


        public ICRE007002Controller(IManejadorRequestQueue<APICRE007002MessageRequest> _manejadorRequestQueue
            , IManejadorResponseQueue2<APICRE007002MessageResponse> _manejadorReponseQueue
            , IHomologacionService<ResponseHomologa> _homologacionRequest)
        {
            // _logger = logger;
            manejadorRequestQueue = _manejadorRequestQueue;
            manejadorReponseQueue = _manejadorReponseQueue;
            homologacionRequest = _homologacionRequest;
        }
     [HttpPost]
     [Route("APICRE007002")]
        public async Task<ActionResult<APICRE007002MessageResponse>> APICRE007002(APICRE007002MessageRequest parametrorequest)
        {
            try
            {
                string DataAreaId = parametrorequest.DataAreaId;
                ResponseHomologa ResuldatoHomologa = await homologacionRequest.GetHomologacion(sbUriHomologacionDynamic, sbMetodoWsUriSiac, DataAreaId);
                // mapear resultado homologacion
                //parametrorequest.DataAreaId = ResuldatoHomologa?.Response ?? "0001";
                parametrorequest.DataAreaId = ResuldatoHomologa?.Response ?? parametrorequest.DataAreaId;
                if (parametrorequest.DataAreaId == null)
                {
                    parametrorequest.DataAreaId = "0001";
                }
                // asignar campo ambiente
                parametrorequest.Enviroment = Entorno;

                APICRE007002MessageResponse respuesta = null;
                string sesionid = Guid.NewGuid().ToString();
                parametrorequest.SessionId = sesionid;

                await manejadorRequestQueue.EnviarMensajeAsync(sesionid, sbConenctionStringEnvio, nombrecolarequest, parametrorequest);

                respuesta = await manejadorReponseQueue.RecibeMensajeSesion(sbConenctionStringReceptar, nombrecolaresponse, sesionid, vl_Time, 3);

                if (respuesta == null)
                {
                    respuestaLog = JsonConvert.SerializeObject(parametrorequest);
                    Logger.FileLogger("APICRE007002", "No se retorno resultado de Dynamics. " + "\r\n" + " Request Recibido: " + respuestaLog);

                    return StatusCode(StatusCodes.Status204NoContent, "No se retorno resultado de dynamics");
                }
                else
                {
                    string respuestaLog = JsonConvert.SerializeObject(respuesta);
                    Logger.FileLogger("APICRE007002", respuestaLog);
                    return Ok(respuesta);
                }
            }
            catch (Exception ex)
            {
                respuestaLog = JsonConvert.SerializeObject(parametrorequest);
                Logger.FileLogger("APICRE007002", ex.ToString() + "\r\n" + " Request: " + respuestaLog);

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }

    }

}
