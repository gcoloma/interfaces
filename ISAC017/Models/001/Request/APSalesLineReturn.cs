using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAC017.api.Models._001.Request
{
    public class APSalesLineReturn
    {
        public string ItemdId { get; set; }
        public decimal Qty { get; set; }
        public string SerialId { get; set; }
        public decimal Monto { get; set; }

    }
}
