using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE_002.Models._003.Response
{
    public class APICRE002003MessageResponse
    {
        public Guid SessionId { get; set; }//Id de sesión

        public string DescriptionId { get; set; }//Descripción de la transaccion

        public List<string> ErrorList { get; set; }//Detalle del error
    }
}
