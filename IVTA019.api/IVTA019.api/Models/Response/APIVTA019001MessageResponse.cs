using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVTA019.api.Models.Response
{
    public class APIVTA019001MessageResponse
    {
        public Guid SessionId { get; set; }
        public Boolean StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
