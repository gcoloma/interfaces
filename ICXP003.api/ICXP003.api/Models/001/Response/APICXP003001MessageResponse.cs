using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICXP003.api.Models._001.Response
{
    public class APICXP003001MessageResponse
    {
        public Guid SesionId { get; set; }
        public List<APVendorContract> APVendorContractList { get; set; }
        public string DescriptionId { get; set; }
        public string[] ErrorList { get; set; }

    }
}
