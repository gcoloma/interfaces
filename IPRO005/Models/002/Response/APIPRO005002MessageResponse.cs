using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO005.api.Models._002.Response
{
    public class APIPRO005002MessageResponse
    {
        public Guid SessionId { get; set; }
        public APItemsContractIPRO001002[] ItemIdList { get; set; }
        public bool StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
