using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO002.api.Models._004.Response
{
    public class APIPRO002004MessageResponse
    {
        public Guid SessionId { get; set; }
        public List<APInventTransIPRO002004> APInventTransList { get; set; }
        public Boolean StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
