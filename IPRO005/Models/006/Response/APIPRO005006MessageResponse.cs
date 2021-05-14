using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO005.api.Models._006.Response
{
    public class APIPRO005006MessageResponse
    {
        public Guid SessionId { get; set; }
        public APMovementSearchContract[] APMovementSearchContract { get; set; }
        public bool StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
