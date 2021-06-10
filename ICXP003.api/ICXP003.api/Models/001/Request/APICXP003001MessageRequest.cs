using ICXP003.api.Models._001.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICXP003.api.Models._001.Request
{
    public class APICXP003001MessageRequest
    {
        public string DataAreaId { get; set; }
        public string SesionId { get; set; }
        public string Enviroment { get; set; }
        public List<PCreateVendorContract> APCreateVendorContract { get; set; }
    }
}
