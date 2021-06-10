using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO012.Models._006
{
    public class APIPRO012006MessageResponse
    {
        public Guid SessionId { get; set; }
        public List<CCInventLocation> APInventLocationList { get; set; }
    }
}
