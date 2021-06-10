using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO005.api.Models._005.Response
{
    public class APIPRO005005MessageResponse
    {
        public string SessionId { get; set; }
        public APTransfersSearchContract[] APTransfersSearchContract { get; set; }
        public bool StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
