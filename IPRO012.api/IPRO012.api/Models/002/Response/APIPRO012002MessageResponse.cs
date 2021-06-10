using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO012.Models._002
{
    public class APIPRO012002MessageResponse
    {
        public Guid SessionId { get; set; }
        public List<CCInventTable> APInventTableList { get; set; }
    }
}
