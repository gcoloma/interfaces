using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVTA005.api.Models._001.Response
{
    public class APSalesOrderCanceled
    {
        public string salesId { get; set; }
        public string salesStatus { get; set; }
        public DateTime dateCanceled { get; set; }

    }
}
