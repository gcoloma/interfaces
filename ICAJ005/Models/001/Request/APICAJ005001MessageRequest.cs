using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ005.api.Models._001.Request
{
    public class APICAJ005001MessageRequest
    {
        public string DataAreaId { get; set; }
        public string SessionId { get; set; }
        public string Enviroment { get; set; }
        public APLedgerJournalDepositsRequest[] LedgerJournalDepositsRequestList { get; set; }

    }
}
