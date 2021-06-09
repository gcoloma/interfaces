﻿
using ICAJ008.api.Infraestructura.Configuracion;
using ICAJ008.api.Infraestructura.Servicios;
using ICAJ008.api.Models._001.Request;
using ICAJ008.api.Models._001.Response;
using ICAJ008.api.Models.Homologa;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ICAJ008.api.Controllers
{
    
    [ApiController]
    public class ICAJ008001Controller : ControllerBase
    {
        private IManejadorRequestQueue<APICAJ008001MessageRequest> manejadorRequestQueue;
        private IManejadorResponseQueue2<APICAJ008001MessageResponse> manejadorReponseQueue;
        private IHomologacionService<ResponseHomologa> homologacionRequest;
        private static RegistroLog Logger = new RegistroLog();
        private static readonly Configuracion conf = new Configuracion();
        static IConfigurationRoot configuracion = conf.GetConfiguration();
        private static string Entorno = Convert.ToString(configuracion.GetSection("Data").GetSection("ASPNETCORE_ENVIRONMENT").Value);
        private static string sbUriHomologacionDynamic = Convert.ToString(configuracion.GetSection("Data").GetSection("UriHomologacionDynamicSiac").Value);
        private static string sbMetodoWsUriSiac = Convert.ToString(configuracion.GetSection("Data").GetSection("MetodoWsUriSiac").Value);
        private static string sbMetodoWsUriAx = Convert.ToString(configuracion.GetSection("Data").GetSection("MetodoWsUriAx").Value);
        private static string sbConenctionStringEnvio = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringRequest001").Value);
        private static string sbConenctionStringReceptar = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringResponse001").Value);
        private static string nombrecolarequest = configuracion.GetSection("Data").GetSection("QueueRequest001").Value.ToString();
        private static string nombrecolaresponse = configuracion.GetSection("Data").GetSection("QueueResponse001").Value.ToString();
        private static int vl_Time = Convert.ToInt32(configuracion.GetSection("Data").GetSection("TimeSleep").Value);
        string respuestaLog;

        public ICAJ008001Controller(IManejadorRequestQueue<APICAJ008001MessageRequest> _manejadorRequestQueue
            , IManejadorResponseQueue2<APICAJ008001MessageResponse> _manejadorReponseQueue
            , IHomologacionService<ResponseHomologa> _homologacionRequest)
        {
            // _logger = logger;
            manejadorRequestQueue = _manejadorRequestQueue;
            manejadorReponseQueue = _manejadorReponseQueue;
            homologacionRequest = _homologacionRequest;
        }
        [HttpPost]
        [Route("APICAJ008001")]
        public async Task<ActionResult<APICAJ008001MessageResponse>> APICAJ008001(APICAJ008001MessageRequest parametrorequest)
        {

            try
            {
                string DataAreaId = parametrorequest.DataAreaId;
                ResponseHomologa ResuldatoHomologa = await homologacionRequest.GetHomologacion(sbUriHomologacionDynamic, sbMetodoWsUriSiac, DataAreaId);
                // mapear resultado homologacion


                parametrorequest.DataAreaId = ResuldatoHomologa?.Response ?? parametrorequest.DataAreaId;
                if (parametrorequest.DataAreaId == null)
                {
                    parametrorequest.DataAreaId = "0001";
                }
                // asignar campo ambiente
                parametrorequest.Enviroment = Entorno;

                APICAJ008001MessageResponse respuesta = null;
                string sesionid = Guid.NewGuid().ToString();
                parametrorequest.SessionId = sesionid;
                await manejadorRequestQueue.EnviarMensajeAsync(sesionid, sbConenctionStringEnvio, nombrecolarequest, parametrorequest);

                respuesta = await manejadorReponseQueue.RecibeMensajeSesion(sbConenctionStringReceptar, nombrecolaresponse, sesionid, vl_Time, 3);


                if (respuesta == null)
                {
                    respuestaLog = JsonConvert.SerializeObject(parametrorequest);
                    Logger.FileLogger("APICAJ008001", "No se retorno resultado de Dynamics. " + "\r\n" + " Request Recibido: " + respuestaLog);
                    return StatusCode(StatusCodes.Status204NoContent, "No se retorno resultado de dynamics");
                }
                else
                {
                    respuestaLog = JsonConvert.SerializeObject(respuesta);
                    Logger.FileLogger("APICAJ008001", respuestaLog);
                    return Ok(respuesta);
                }

            }
            catch (Exception ex)
            {
                respuestaLog = JsonConvert.SerializeObject(parametrorequest);
                Logger.FileLogger("APICAJ008001", ex.ToString() + "\r\n" + " Request: " + respuestaLog);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }
    }
}
