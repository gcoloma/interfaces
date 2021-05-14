using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO005.api.Models._001.Response
{
    public class APIPRO005001MessageResponse
    {
        public Guid SessionId { get; set; }
        public APItemsContract[] ItemIdList { get; set; }
        public bool StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
