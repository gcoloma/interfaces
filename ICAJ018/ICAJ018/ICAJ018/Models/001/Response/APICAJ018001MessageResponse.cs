using System;
using System.Collections.Generic;
using System.Text;

namespace ICAJ018.Models._001.Response
{
    class APICAJ018001MessageResponse
    {
        public string SessionId { get; set; }
        public Boolean StatusId { get; set; }
        public string[] ErrorList { get; set; }
        public APTypeTransactionResponse[] TypeTransactionList { get; set; }
    }
}
