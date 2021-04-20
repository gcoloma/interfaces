﻿using ICXP003.api.Infraestructure.Configuration;
using ICXP003.api.Infraestructure.Services;
using ICXP003.api.Models._002.Request;
using ICXP003.api.Models._002.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ICXP003.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ICXP003002Controller : ControllerBase
    {
        private IManejadorRequest<APICXP003002MessageRequest> QueueRequest;
        private IManejadorResponse<APICXP003002MessageResponse> QueueResponse;
        private static RegistroLog Logger = new RegistroLog();
        private static readonly Configuracion conf = new Configuracion();
        static IConfigurationRoot configuracion = conf.GetConfiguration();
        private static string vl_ConnectionStringRequest = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringRequest").Value);
        private static string vl_ConnectionStringResponse = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringResponse").Value);
        private static string vl_QueueRequest = configuracion.GetSection("Data").GetSection("QueueRequest").Value.ToString();
        private static string vl_QueueResponse = configuracion.GetSection("Data").GetSection("QueueResponse").Value.ToString();
        private static int vl_Time = Convert.ToInt32(configuracion.GetSection("Data").GetSection("TimeSleep").Value);


        public ICXP003002Controller(IManejadorRequest<APICXP003002MessageRequest> _manejadorRequest, IManejadorResponse<APICXP003002MessageResponse> _manejadorReponse)
        {
            QueueRequest = _manejadorRequest;
            QueueResponse = _manejadorReponse;
        }

     
        [HttpPost]
        
        public async Task<ActionResult<APICXP003002MessageResponse>> APICXP003002(APICXP003002MessageRequest parametrorequest)
        {
            try
            {
                APICXP003002MessageResponse respuesta = null;
                string sesionid = Guid.NewGuid().ToString();
                parametrorequest.SesionId = sesionid;

                await QueueRequest.EnviarMensajeAsync(sesionid, vl_ConnectionStringRequest, vl_QueueRequest, parametrorequest);

                respuesta = await QueueResponse.RecibeMensajeSesion(vl_ConnectionStringResponse, vl_QueueResponse, sesionid, 1, 3);


                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                Logger.FileLogger("APICXP003002", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }

    }
}