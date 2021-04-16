using ICRE_002.Models._002.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE_002.Models._002.Response
{
    public class APICRE002002MessageResponse
    {
        public string SessionId { get; set; }//Id de sesión
        //public APIndependetEntrep2 APIndependetEntrep { get; set; }//Objeto Emprendedor Independiente
        public string DescriptionId { get; set; }//Descripción "OK" "ERROR"
        public List<string> ErrorList { get; set; }//Detalle del error
    }
}
