using System;
using System.Collections.Generic;
using System.Text;

namespace ILOG002.Models._004.Request
{
    public class APPackageShippifyCanceledRequest
    {
        public string PackageShippifyId { get; set; }
        public string ReasonCode { get; set; }
        public string ReasonDescrption { get; set; }
        public string CancelNote { get; set; }        
    }
}
