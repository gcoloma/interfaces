using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE002.api.Models._003.Request
{
    public class APICRE002003MessageRequest
    {
        //  Para ejecutar la actualización primero deben consultar información del cliente método definido en el ICRE-006.
        public string DataAreaId { get; set; }//Id de la compañía (6)
        public string Enviroment { get; set; }
        public string SessionId { get; set; }//Id de sesión
        public string AccountNum { get; set; }//Código del cliente.
        public string IndependentEntrepreneurId { get; set; }//Código NETZEN
    }
    
}
