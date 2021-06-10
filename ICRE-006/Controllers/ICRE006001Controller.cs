

using ICRE006.api.Infraestructura.Servicios;
using ICRE006.api.Infraestructure.Configuration;
using ICRE006.api.Infraestructure.Services;
using ICRE006.api.Models._001.Request;
using ICRE006.api.Models._001.Response;
using ICRE006.api.Models.Homologacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE006.api.Controllers
{
    
    [ApiController]
    public class ICRE006001Controller : ControllerBase
    {
        //PROPIEDADES DE COLAS
        private IManejadorRequest<APICRE006001MessageRequest> QueueRequest;
        private IManejadorResponse<APCustTableResponse> QueueResponse;
        //PROPIEDAD DE HOMOLOGACION
        private IHomologacionService<ResponseHomologa> homologacionRequest;
        //PROPIEDADES DE  CONFIGURACION Y REGISTROLOG
        private static RegistroLog Logger = new RegistroLog();
        private static readonly Configuracion conf = new Configuracion();
        static IConfigurationRoot configuracion = conf.GetConfiguration();
        //PROPIEDAD ENVIROMENT
        private static string vl_Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToString();
        //PROPIEDADES DE CADENA DE CONEXION
        private static string vl_ConnectionStringRequest = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringRequest").Value);
        private static string vl_ConnectionStringResponse = Convert.ToString(configuracion.GetSection("Data").GetSection("ConectionStringResponse").Value);
        private static string vl_QueueRequest = configuracion.GetSection("Data").GetSection("QueueRequest").Value.ToString();
        private static string vl_QueueResponse = configuracion.GetSection("Data").GetSection("QueueResponse").Value.ToString();
        //PROPIEDADES DE HOMOLOGACION
        private static string sbUriHomologacionDynamic = Convert.ToString(configuracion.GetSection("Data").GetSection("UriHomologacionDynamicSiac").Value);
        private static string sbMetodoWsUriSiac = Convert.ToString(configuracion.GetSection("Data").GetSection("MetodoWsUriSiac").Value);
        private static string sbMetodoWsUriAx = Convert.ToString(configuracion.GetSection("Data").GetSection("MetodoWsUriAx").Value);
        //PROPIEDAD DE TIEMPO
        private static int vl_Time = Convert.ToInt32(configuracion.GetSection("Data").GetSection("TimeSleep").Value);

        public ICRE006001Controller(IManejadorRequest<APICRE006001MessageRequest> _manejadorRequest, IManejadorResponse<APCustTableResponse> _manejadorReponse, IHomologacionService<ResponseHomologa> _homologacionRequest)
        {
            QueueRequest = _manejadorRequest;
            QueueResponse = _manejadorReponse;
            homologacionRequest = _homologacionRequest;
        }


        [HttpPost]
        [Route("APICRE006001")]
        public async Task<ActionResult<APCustTableResponse>> APICRE006001(APICRE006001MessageRequest parametrorequest)
        {
            try
            {
                string DataAreaId = parametrorequest.DataAreaId;
                ResponseHomologa ResuldatoHomologa = await homologacionRequest.GetHomologacion(sbUriHomologacionDynamic, sbMetodoWsUriSiac, DataAreaId);
                // mapear resultado homologacion
                parametrorequest.DataAreaId = ResuldatoHomologa?.Response ?? "0001";
                // asignar campo ambiente
                parametrorequest.Enviroment = vl_Environment;
                APCustTableResponse respuesta = null;
                string sesionid = Guid.NewGuid().ToString();
                parametrorequest.SessionId = sesionid;


                await QueueRequest.EnviarMensajeAsync(sesionid, vl_ConnectionStringRequest, vl_QueueRequest, parametrorequest);

                respuesta = await QueueResponse.RecibeMensajeSesion(vl_ConnectionStringResponse, vl_QueueResponse, sesionid, 1, 3);

                if (respuesta == null)
                {
                    Logger.FileLogger("APICRE006001", "No se retorno resultado de Dynamics");
                    return StatusCode(StatusCodes.Status204NoContent, "No se retorno resultado de dynamics");
                }

                return Ok(parametrorequest);
            }
            catch (Exception ex)
            {
                Logger.FileLogger("APICRE006001", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }
    }
}
