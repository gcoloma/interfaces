using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ001.api.Models._001.Response
{
    public class APICAJ001001MessageResponse
    {
        public APBankAccountTable[] BankAccountTableList { get; set; }
        public bool StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
