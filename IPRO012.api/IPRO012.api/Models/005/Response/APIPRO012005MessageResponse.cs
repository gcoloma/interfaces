using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO012.Models._005
{
    public class APIPRO012005MessageResponse
    {
        public Guid SessionId { get; set; }
        public List<CCInventPackingGroup> APInventPackingGroupList { get; set; }
    }
}
