using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ003.api.Models._001.Response
{
    public class APICAJ003001MessageResponse
    {
        public string SessionId { get; set; }
        public APLedgerJournalTableCustPaym2 APLedgerJournalTableCustPaym { get; set; }
        public Boolean StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
