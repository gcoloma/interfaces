using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ005.Models._001.Response
{
    public class APICAJ005001MessageResponse
    {
        public List<APLedgerJournalDepositsResponse> LedgerJournalDepositsResponseList { get; set; }
        public bool StatusId { get; set; }
        public List<string> ErrorList { get; set; }
    }
}
