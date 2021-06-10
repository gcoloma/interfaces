using System;
using System.Collections.Generic;
using System.Text;

namespace ICAJ018.Models._001.Response
{
    class APTypeTransactionResponse
    {
        public TypeTransactionDeposit TypeTransactionDeposit { get; set; }
        public APDocumentDeposit[] DocumentDepositList { get; set; }

    }

}
    
