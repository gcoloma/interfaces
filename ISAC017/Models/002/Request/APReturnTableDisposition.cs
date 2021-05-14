using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAC017.api.Models._002.Request
{
    public class APReturnTableDisposition
    {
        public string ReturnItemNum { get; set; }
        public string ItemdId { get; set; }
        public decimal Qty { get; set; }
        public string DispositionCodeId { get; set; }
        public string InventLocationId { get; set; }
        public string WMSLocationId { get; set; }
    }
}
