using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE007.api.Models._001.Request
{
    public class APICRE007001MessageRequestLegado
    {
        
        // 001 consulta de grupos de Clientes
        public string DataAreaId { get; set; }//Id de la compañía 

        public string prioridad { get; set; }//Prioridad 

        public string SessionId { get; set; }//Id de sesión Guid
    }
}

