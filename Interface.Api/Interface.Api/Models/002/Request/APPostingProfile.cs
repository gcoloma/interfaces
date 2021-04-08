using Interface.Api.Models.ICRE007001.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.Api.Models.ICRE007002.Request
{
    public class APPostingProfile
    {
        public string PostingProfile { get; set; }
        public string Description { get; set; }
        public List<APCustGroup> CustGroupList { get; set; }
    }
}
