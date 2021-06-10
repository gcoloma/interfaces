using System;
using System.Collections.Generic;
using System.Text;

namespace ICXP003.Models.Request
{
    class APLedgerInvoiceContract
    {
        public string Period { get; set; }
        public string APCodeIndependentVend { get; set; }
        public string RUC { get; set; }
        public string InvoiceNumber { get; set; }
        public string PaymMode { get; set; }
        public string P { get; set; }//preguntar
        public DateTime PaymentDate { get; set; }
    }
}
