using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICOB001.api.Models._001.Request
{
    public class APICOB001001MessageRequest
    {
        public string DataAreaId { get; set; }
        public string Enviroment { get; set; }        
        public List<APSettlementTransactionHeader> APSettlementTransactionHeaderList { get; set; }
        public string CustAccount { get; set; }
        public string SessionId { get; set; }
    }
}
