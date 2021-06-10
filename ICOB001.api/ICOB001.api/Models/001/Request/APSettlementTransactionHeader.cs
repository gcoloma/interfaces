using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICOB001.api.Models._001.Request
{
    public class APSettlementTransactionHeader
    {
        public string VoucherSettlement { get; set; }
        public string IdReciboCobro { get; set; }
        public DateTime DateTrans { get; set; }
        public string InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public List<APDocumentICOB001001> APDocumentList { get; set; }
        public Boolean StatusId { get; set; }
    }
}
