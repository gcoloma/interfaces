using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCAJ017.api.Models._001.Request
{
    public class APDCAJ017001MessageRequest
    {
        public string DataAreaId { get; set; }
        public string Enviroment { get; set; }
        public string SessionId { get; set; }
        public string CustAccount { get; set; }
        public string InputCustId { get; set; }
        public string OparationId { get; set; }
        public decimal Amount { get; set; }
        public string PostingProfile { get; set; }
        public string PostingProfileAdvance { get; set; }
    }
}
