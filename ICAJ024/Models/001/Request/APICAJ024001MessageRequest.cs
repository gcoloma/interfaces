using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ024.Models._001.Request
{
    public class APICAJ024001MessageRequest
    {
        public string DataAreaId { get; set; }
        public string Enviroment { get; set; }
        public string SessionId { get; set; }
        public string CustAccount { get; set; }
        public string NumCreditNote { get; set; }
        public DateTime DateCreditNote { get; set; }
        public string VoucherCreditNote { get; set; }
        public string RubroSIAC { get; set; }
        public double AmountDebitNote { get; set; }
        public List<APDocumentLiquidateRequest> DocumentLiquidateList { get; set; }
    }
}
