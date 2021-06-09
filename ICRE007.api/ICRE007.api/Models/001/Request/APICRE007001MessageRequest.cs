using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE007.api.Models._001.Request
{
    public class APICRE007001MessageRequest
    {
         
        // 001 consulta de grupos de Clientes
        public string DataAreaId { get; set; }//Id de la compañía 

        public string prioridad { get; set; }//Prioridad 

        public string SessionId { get; set; }//Id de sesión GUID
        public string Enviroment { get; set; } //Id del ambiente

    }
   // public enum Prioridad { Bajo = 0, Medio = 1, Alto = 2 }
}

