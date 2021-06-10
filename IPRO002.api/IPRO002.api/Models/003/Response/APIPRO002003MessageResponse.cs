using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO002.api.Models._003.Response
{
    public class APIPRO002003MessageResponse
    {
        public Guid SessionId { get; set; }
        public List<APInventTableIPRO002003> APInventTableList { get; set; }
        public Boolean StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
