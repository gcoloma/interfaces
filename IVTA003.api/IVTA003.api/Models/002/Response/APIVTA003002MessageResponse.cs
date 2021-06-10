using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVTA003.api.Models._002.Response
{
    public class APIVTA003002MessageResponse
    {
        public Guid SessionId { get; set; }
        public List<APInventTableIVTA003002> APInventTableList { get; set; }
        public Boolean StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
