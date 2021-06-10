using System;
using System.Collections.Generic;
using System.Text;

namespace ICXP003.Models.Request
{
    class APICXP003003MessageRequest
    {
        public string DataAreaId { get; set; }
        public string Enviroment { get; set; }
        public List<APLedgerInvoiceContract> APLedgerInvoiceContract { get; set; }
    }
}
