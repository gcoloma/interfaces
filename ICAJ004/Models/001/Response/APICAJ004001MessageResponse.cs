using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ004.Models.Response
{
    public class APICAJ004001MessageResponse
    {
        public List<APLedgerJournalCashDepositsResponse> LedgerJournalCashDepositsResponseList { get; set; }
        public bool StatusId { get; set; }
        public List<string> ErrorList { get; set; }
    }
}
