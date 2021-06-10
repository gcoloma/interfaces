using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO002.api.Models._001.Response
{
    public class APIPRO002001MessageResponse
    {       
        public Guid SessionId { get; set; }
        public List<APInventTransIPRO002001> APInventTransList { get; set; }
        public Boolean StatusId { get; set; }
        public string[] ErrorList { get; set; }
        
    }
}
