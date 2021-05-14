using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE002.api.Models._003.Response
{
    public class APICRE002003MessageResponse
    {
        public string SessionId { get; set; }//Id de sesión

        public string DescriptionId { get; set; }//Descripción de la transaccion

        public List<string> ErrorList { get; set; }//Detalle del error
    }
}
