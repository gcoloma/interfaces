using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCAJ017.api.Models._003.Response
{
    public class APDCAJ017003MessageResponse
    {
        public string SessionId { get; set; }
        public string StatusId { get; set; }
        public string[] ErrorList { get; set; }
        public string CustAccount { get; set; }
        public string InputCustId { get; set; }
        public string CheckStatus { get; set; }
    }
}
