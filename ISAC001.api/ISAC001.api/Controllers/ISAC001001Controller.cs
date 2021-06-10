using ISAC001.api.Infraestructura.Configuracion;
using ISAC001.api.Infraestructura.Servicios;
using ISAC001.api.Models._001.Request;
using ISAC001.api.Models._001.Response;
using ISAC001.api.Models.Homologacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAC001.api.Controllers
{
    
    [ApiController]
    public class ISAC001001Controller : ControllerBase
    {
        private IManejadorRequestQueue<APISAC001001MessageRequest> manejadorRequestQueue;
        private IManejadorResponseQueue2<APISAC001001MessageResponse> manejadorReponseQueue;
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


        public ISAC001001Controller(IManejadorRequestQueue<APISAC001001MessageRequest> _manejadorRequestQueue
            , IManejadorResponseQueue2<APISAC001001MessageResponse> _manejadorReponseQueue
            , IHomologacionService<ResponseHomologa> _homologacionRequest)
        {
            manejadorRequestQueue = _manejadorRequestQueue;
            manejadorReponseQueue = _manejadorReponseQueue;
            homologacionRequest = _homologacionRequest;
        }
        [HttpPost]
        [Route("APISAC001001")]
        public async Task<ActionResult<APISAC001001MessageResponse>> APISAC001001(APISAC001001MessageRequest parametrorequest)
        {
            try
            {
                string DataAreaId = parametrorequest.DataAreaId;
                ResponseHomologa ResuldatoHomologa = await homologacionRequest.GetHomologacion(sbUriHomologacionDynamic, sbMetodoWsUriSiac, DataAreaId);
                // mapear resultado homologacion
                parametrorequest.DataAreaId = ResuldatoHomologa?.Response ?? "0001";
                // asignar campo ambiente
                parametrorequest.Enviroment = Entorno;
                

                // primer elemento //APENTAssetObjectTable objTemp =  parametrorequest.APENTAssetObjectTableList.FirstOrDefault();
                // primer elemento //objTemp.Model = "Y";  // 

                // todos los elementos foreach
                ///List<APENTAssetObjectTable> lsObjTemp = parametrorequest.APENTAssetObjectTableList;
                ///ResponseHomologa ResuldatoHomologaLista;
                ///foreach (var det in lsObjTemp)
                ///{
                ///    ResuldatoHomologaLista = await homologacionRequest.GetHomologacion(sbUriHomologacionDynamic, sbMetodoWsUriSiac, det.Model);
                ///    det.Model = ResuldatoHomologaLista?.Response ?? "0001"; ;
                ///}
                // haasta aqui foreach
                // agregar alemento // Add(new APENTAssetObjectTable {Model = "REsultado_Marca" }); 


                APISAC001001MessageResponse respuesta = null;
                string sesionid = Guid.NewGuid().ToString();
                parametrorequest.SessionId = sesionid;

                await manejadorRequestQueue.EnviarMensajeAsync(sesionid, sbConenctionStringEnvio, nombrecolarequest, parametrorequest);

                respuesta = await manejadorReponseQueue.RecibeMensajeSesion(sbConenctionStringReceptar, nombrecolaresponse, sesionid, vl_Time, 3);

                if (respuesta == null)
                {
                    respuestaLog = JsonConvert.SerializeObject(parametrorequest);
                    Logger.FileLogger("ISAC001001", "No se retorno resultado de Dynamics. " + "\r\n" + " Request Recibido: " + respuestaLog);
                    return StatusCode(StatusCodes.Status204NoContent, "No se retorno resultado de dynamics");
                }
                else
                {
                    respuestaLog = JsonConvert.SerializeObject(respuesta);
                    Logger.FileLogger("ISAC001001", respuestaLog);
                    return Ok(respuesta);
                }
            }
            catch (Exception ex)
            {
                respuestaLog = JsonConvert.SerializeObject(parametrorequest);
                Logger.FileLogger("APIPRO007001", ex.ToString() + "\r\n" + " Request: " + respuestaLog);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }
    }
}
