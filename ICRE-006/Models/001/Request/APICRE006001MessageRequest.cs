using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE006.Models._001.Request
{
    public class APICRE006001MessageRequest
    {
        public string VATNum { get; set; }
        public string SesionId { get; set; }//Agregado
        public string DataAreaId { get; set; }
        public string Enviroment { get; set; }
        
    }
    
}
