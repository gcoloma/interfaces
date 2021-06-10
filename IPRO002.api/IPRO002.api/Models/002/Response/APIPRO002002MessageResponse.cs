using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO002.api.Models._002.Response
{
    public class APIPRO002002MessageResponse
    {
        public Guid SessionId { get; set; }
        public List<APInventTableIPRO002002> APInventTableList { get; set; }
        public Boolean StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
