using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO012.Models._003
{
    public class APIPRO012003MessageResponse
    {
        public Guid SessionId { get; set; }
        public List<CCInventTableBusinessUnit> APInventTableBusinessUnitList { get; set; }
    }
}
