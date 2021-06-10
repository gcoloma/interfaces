using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICXP003.api.Models._001.Response
{
    public class APVendorContract
    {
        public APCreateVendorContract APCreateVendorContract { get; set; }
        public string DescriptionId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
