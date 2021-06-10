using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ012.api.Models._001.Response
{
    public class APICAJ012001MessageResponse
    {
        public Guid SessionId { get; set; }
        public bool StatusId { get; set; }
        public string[] ErrorList { get; set; }
        public string APReasonIngressEgressId { get; set; }
        public APLedgerJournalTransICAJ012_[] APLedgerJournalTransList { get; set; }
    }
}
