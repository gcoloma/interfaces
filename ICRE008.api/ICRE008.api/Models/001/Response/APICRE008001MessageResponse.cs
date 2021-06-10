using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE008.api.Models._001.Response
{
    public class APICRE008001MessageResponse
    {
        public Guid SessionId { get; set; }
        public APICRE008001InvoiceOrder[] APICRE008001InvoiceOrderList { get; set; }
        public string StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
