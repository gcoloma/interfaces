using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAC017.api.Models._001.Request
{
    public class APSalesTableReturn
    {
        public string CustAccount { get; set; }
        public string InvoiceId { get; set; }
        public DateTime ReturnDeadline { get; set; }
        public string ReturnReasonCodeId { get; set; }
        public string ReturnReasonComment { get; set; }
        public APSalesLineReturn[] APSalesLineReturnList { get; set; }
    }
}
