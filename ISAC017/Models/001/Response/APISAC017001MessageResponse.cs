using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAC017.api.Models._001.Response
{
    public class APISAC017001MessageResponse
    {
        public Guid SessionId { get; set; }
        public string ReturnItemNum { get; set; }
        public bool StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
