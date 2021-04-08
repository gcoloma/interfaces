using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE007.api.Models._002.Request
{
    public class APICRE007002MessageRequest
    {
         
        // 002 consulta de perfiles de asiento contable de Clientes
        public string DataAreaId { get; set; }//Id de la compañía 

        public Prioridad prioridad { get; set; }//Prioridad 

        public Guid SessionId { get; set; }//Id de sesión
    }
    public enum Prioridad { Bajo = 0, Medio = 1, Alto = 2 }
}

