using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ024.Models._001.Request

{
    public class APDocumentLiquidateRequest
    {
        public string InvoiceLiquidate { get; set; }
        public string VoucherLiquidate { get; set; }
        public string NumSettleVoucher { get; set; }
    }
}
