﻿using ICRE_002.Infraestructure.Configuracion;
using ICRE_002.Infraestructure.Services;
using ICRE_002.Models._002.Request;
using ICRE_002.Models._002.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE_002.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ICRE002002Controller : ControllerBase
    {
        private IManejadorRequest<APICRE002002MessageRequest> QueueRequest;
        private IManejadorResponse<APICRE002002MessageResponse> QueueResponse;
        private static RegistroLog Logger = new RegistroLog();
        private static readonly Configuracion conf = new Configuracion();
        static IConfigurationRoot configuracion = conf.GetConfiguration();
        private static string vl_ConnectionStringRequest = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringRequest").Value.ToString());
        private static string vl_ConnectionStringResponse = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringResponse").Value.ToString());
        private static string vl_QueueRequest = configuracion.GetSection("Data").GetSection("QueueRequest").Value.ToString();
        private static string vl_QueueResponse = configuracion.GetSection("Data").GetSection("QueueResponse").Value.ToString();
        private static int vl_Time = Convert.ToInt32(configuracion.GetSection("Data").GetSection("TimeSleep").Value);
        private static string vl_Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToString();


        public ICRE002002Controller(IManejadorRequest<APICRE002002MessageRequest> _manejadorRequest, IManejadorResponse<APICRE002002MessageResponse> _manejadorReponse)
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
        public async Task<ActionResult<APICRE002002MessageResponse>> ICRE002002(APICRE002002MessageRequest parametrorequest)
        {
            try
            {
                APICRE002002MessageResponse respuesta = null;
                string sesionid = Guid.NewGuid().ToString();

                parametrorequest.SessionId = sesionid;
                parametrorequest.Enviroment = vl_Environment;

                await QueueRequest.EnviarMensajeAsync(sesionid, vl_ConnectionStringRequest, vl_QueueRequest, parametrorequest);

                respuesta = await QueueResponse.RecibeMensajeSesion(vl_ConnectionStringResponse, vl_QueueResponse, sesionid, 1, 3);


                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                Logger.FileLogger("ICRE002002", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }
    }
}