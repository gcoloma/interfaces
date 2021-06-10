using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILOG002.api.Models._001.Response
{
    public class APPackageShippifyResponse
    {
        public string PackageShippifyId { get; set; }
        public StatusEnum StatusShippify { get; set; }
        public string PackingSlipId { get; set; }
    }
}
