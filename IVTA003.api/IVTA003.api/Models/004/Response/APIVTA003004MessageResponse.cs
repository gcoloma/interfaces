using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVTA003.api.Models._004.Response
{
    public class APIVTA003004MessageResponse
    {
        public Guid SessionId { get; set; }
        public List<APInventLocationIPRO002004> APInventlocationList { get; set; }
        public Boolean StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
