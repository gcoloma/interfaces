using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE002.api.Models.Response
{
    public class APICRE002001MessageResponse
    {
     
        public string SessionId { get; set; }//Id de sesión
        public APCustTableICRE002001 APCustTable { get; set; }//Cliente
        public string DescriptionId { get; set; }//Descripción -- OK, "ERROR"
        public string[] ErrorList { get; set; }//Detalle del error
    }
}
