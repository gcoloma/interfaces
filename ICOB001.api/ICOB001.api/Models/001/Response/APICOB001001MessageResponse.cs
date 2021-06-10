using ICOB001.api.Models._001.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICOB001.api.Models._001.Response
{
    public class APICOB001001MessageResponse
    {
        public Guid SessionId { get; set; }
        public List<APSettlementTransactionHeader> APSettlementTransactionHeaderList { get; set; }
        public Boolean StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
