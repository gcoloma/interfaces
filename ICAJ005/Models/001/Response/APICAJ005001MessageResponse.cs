using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ005.api.Models._001.Response
{
    public class APICAJ005001MessageResponse
    {
        public APLedgerJournalDepositsResponse[] LedgerJournalDepositsResponseList { get; set; }
        public bool StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
