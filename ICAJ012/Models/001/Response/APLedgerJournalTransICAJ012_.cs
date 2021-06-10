using ICAJ012.api.Models._001.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ012.api.Models._001.Response
{
    public class APLedgerJournalTransICAJ012_
    {
        public string Voucher { get; set; }
        public LedgerJournalACType AccountType { get; set; }
        public string Account { get; set; }
        public LedgerJournalACType OffsetAccountType { get; set; }
        public string OffSetAccount { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string DocumentNum { get; set; }
    }
    
}
