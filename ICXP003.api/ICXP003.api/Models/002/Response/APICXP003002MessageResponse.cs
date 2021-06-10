using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICXP003.api.Models._002.Response
{
    public class APICXP003002MessageResponse
    {
        public Guid SessionId { get; set; }
        public string Diario_de_factura { get; set; }
        public string Voucher { get; set; }//preguntar 
        public string StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
