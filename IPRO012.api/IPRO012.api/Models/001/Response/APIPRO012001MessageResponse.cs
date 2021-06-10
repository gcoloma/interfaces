using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO012.Models._001
{
    public class APIPRO012001MessageResponse
    {
        public Guid SessionId { get; set; }
        public List<CCTAMFundTable> APTAMFundTableList { get; set; }
    }
}
