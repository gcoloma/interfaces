using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAC020.Models.Response
{
    public class APISAC020001MessageResponse
    {
        public Guid SessionId { get; set; }
        public string TransferId { get; set; }
        public Boolean StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
