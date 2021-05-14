using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ004.api.Models.Response
{
    public class APICAJ004001MessageResponse
    {
        public APLedgerJournalCashDepositsResponse[] LedgerJournalCashDepositsResponseList { get; set; }
        public bool StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
