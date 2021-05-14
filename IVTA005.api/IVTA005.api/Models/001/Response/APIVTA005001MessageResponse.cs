using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVTA005.api.Models._001.Response
{
    public class APIVTA005001MessageResponse
    {
        public string statusId { get; set; }
        public string[] errorList { get; set; }
        public APSalesOrderCanceled salesOrderCanceled { get; set; }
    }
}
