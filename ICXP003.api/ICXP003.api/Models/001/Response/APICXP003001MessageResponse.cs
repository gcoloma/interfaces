using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICXP003.api.Models._001.Response
{
    public class APICXP003001MessageResponse
    {
        public Guid SessionId { get; set; }
        public List<APVendorContract> APVendorContractList { get; set; }
        public string StatusId { get; set; }
        public string[] ErrorList { get; set; }

    }
}
