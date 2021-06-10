using System;
using System.Collections.Generic;
using System.Text;

namespace FNC_ICXP003.Models._001.Request
{
    public class APICXP003003MessageResponse
    {
        public string DataAreaId { get; set; }
        public List<APLedgerInvoiceContract> APLedgerInvoiceContract { get; set; }
    }
}
