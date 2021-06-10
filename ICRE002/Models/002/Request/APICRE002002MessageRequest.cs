using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE002.api.Models._002.Request
{
    public class APICRE002002MessageRequest
    {
        public string DataAreaId { get; set; }//Id de la compañía 
        public string Enviroment { get; set; }
        public string SessionId { get; set; }//Id de sesión
        public APIndependetEntrep2 APIndependetEntrep { get; set; }//Objeto Emprendedor Independiente
    }
}
