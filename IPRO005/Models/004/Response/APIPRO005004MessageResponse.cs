using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO005.api.Models._004.Response
{
    public class APIPRO005004MessageResponse
    {
        public Guid SessionId { get; set; }
        public APItemsContractIPRO005004[] ItemsList { get; set; }
        public bool StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
