using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE004.api.Models._001.Response
{
    public class APICRE004001MessageResponse
    {
        public Guid SessionId { get; set; }
        public List<APSalesOrderICRE004001> APSalesOrderList { get; set; }
        public Boolean StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
