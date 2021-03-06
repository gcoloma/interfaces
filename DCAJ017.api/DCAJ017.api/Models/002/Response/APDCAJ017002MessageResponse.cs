using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCAJ017.api.Models._002.Response
{
    public class APDCAJ017002MessageResponse
    {
        public string SessionId { get; set; }
        public string StatusId { get; set; }
        public string[] ErrorList { get; set; }
        public string CustAccount { get; set; }
        public string InputCustId { get; set; }
        public string OparationId { get; set; }
        public string InventTransId { get; set; }
        public decimal Amount { get; set; }
        public string BankId { get; set; }
        public string CheckStatus { get; set; }
    }
}
