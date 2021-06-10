using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVTA003.api.Models._001.Response
{
    public class APIVTA003001MessageResponse
    {
        public Guid SessionId { get; set; }
        public List<APCustTableIVTA003001> APCustTableList { get; set; }
        public Boolean StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
