using System;
using System.Collections.Generic;
using System.Text;

namespace FNC_ICXP003.Models._001.Request
{
    public class APLedgerInvoiceContract
    {
        public string Period { get; set; }
        public string APCodeIndependentVend { get; set; }
        public string RUC { get; set; }
        public string InvoiceNumber { get; set; }
        public string PaymMode { get; set; }

        //P Este campo no se entiende
        public DateTime Payment_Date { get; set; }
    }
    public enum EnumPSalesStatus { None = 0, Backorder = 1, Delivered = 2, Invoiced = 3, Canceled = 4 }
}
