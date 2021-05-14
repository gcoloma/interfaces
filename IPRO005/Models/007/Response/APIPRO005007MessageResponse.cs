using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO005.api.Models._007.Response
{
    public class APIPRO005007MessageResponse
    {
        public Guid SessionId { get; set; }
        public APDistributionCentersContract[] APDistributionCentersContract { get; set; }
        public bool StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
