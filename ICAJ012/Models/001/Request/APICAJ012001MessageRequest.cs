using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ012.api.Models._001.Request
{
    public class APICAJ012001MessageRequest
    {
        public string DataAreaId { get; set; }
        public string Enviroment { get; set; }
        public string SessionId { get; set; }
        public string APReasonIngressEgressId { get; set; }
        public  APLedgerJournalTransICAJ012[] APLedgerJournalTransList { get; set; }
    }
}
