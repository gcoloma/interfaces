using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICOB001.api.Models._001.Request
{
    public class APDocumentICOB001001
    {
        public string Voucher { get; set; }
        public string InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public string VoucherId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
