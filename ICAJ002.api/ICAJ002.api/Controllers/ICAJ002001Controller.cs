using ICAJ002.api.Infraestructura.Configuracion;
using ICAJ002.api.Infraestructura.Servicios;
using ICAJ002.api.Models;
using ICAJ002.api.Models._001.Request;
using ICAJ002.api.Models._001.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ICAJ002.api.Controllers
{
    
    [ApiController]
    public class ICAJ002001Controller : ControllerBase
    {

        private IManejadorRequestQueue<APICAJ002001MessageRequest> manejadorRequestQueue;
        private IManejadorResponseQueue2<APICAJ002001MessageResponse> manejadorReponseQueue;
        private IHomologacionService<ResponseHomologa> homologacionRequest;
        private static RegistroLog Logger = new RegistroLog();
        private static readonly Configuracion conf = new Configuracion();
        static IConfigurationRoot configuracion = conf.GetConfiguration();
        private static string Entorno = Convert.ToString(configuracion.GetSection("Data").GetSection("por correo . q?").Value);
        private static string sbUriHomologacionDynamic = Convert.ToString(configuracion.GetSection("Data").GetSection("UriHomologacionDynamicSiac").Value);
        private static string sbMetodoWsUriSiac = Convert.ToString(configuracion.GetSection("Data").GetSection("MetodoWsUriSiac").Value);
        private static string sbMetodoWsUriAx = Convert.ToString(configuracion.GetSection("Data").GetSection("MetodoWsUriAx").Value);
        private static string sbConenctionStringEnvio = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringRequest001").Value);
        private static string sbConenctionStringReceptar = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringResponse001").Value);
        private static string nombrecolarequest = configuracion.GetSection("Data").GetSection("QueueRequest001").Value.ToString();
        private static string nombrecolaresponse = configuracion.GetSection("Data").GetSection("QueueResponse001").Value.ToString();
        private static int vl_Time = Convert.ToInt32(configuracion.GetSection("Data").GetSection("TimeSleep").Value);
        public ICAJ002001Controller(IManejadorRequestQueue<APICAJ002001MessageRequest> _manejadorRequestQueue
            , IManejadorResponseQueue2<APICAJ002001MessageResponse> _manejadorReponseQueue
            , IHomologacionService<ResponseHomologa> _homologacionRequest)
        {
            manejadorRequestQueue = _manejadorRequestQueue;
            manejadorReponseQueue = _manejadorReponseQueue;
            homologacionRequest = _homologacionRequest;
        }
        [HttpPost]
        [Route("APICAJ002001")]
        public async Task<ActionResult<APICAJ002001MessageResponse>> APICAJ002001(APICAJ002001MessageRequest parametrorequest)
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

                APICAJ002001MessageResponse respuesta = null;
                string sesionid = Guid.NewGuid().ToString();
                parametrorequest.SessionId = sesionid;

                await manejadorRequestQueue.EnviarMensajeAsync(sesionid, sbConenctionStringEnvio, nombrecolarequest, parametrorequest);
                respuesta = await manejadorReponseQueue.RecibeMensajeSesion(sbConenctionStringReceptar, nombrecolaresponse, sesionid, vl_Time, 3);
                if (respuesta == null)
                {
                    Logger.FileLogger("APICAJ002001", "No se retorno resultado de Dynamics");
                    return StatusCode(StatusCodes.Status204NoContent, "No se retorno resultado de dynamics");
                }
                else
                {
                    string respuestaLog = JsonConvert.SerializeObject(respuesta);
                    Logger.FileLogger("APICAJ002001", respuestaLog);
                    return Ok(respuesta);
                }
            }
            catch (Exception ex)
            {
                Logger.FileLogger("APICAJ002001", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
               

            }

        }



    }
}
