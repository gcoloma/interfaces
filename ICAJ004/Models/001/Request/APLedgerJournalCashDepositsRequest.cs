using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ004.Models.Request
{
    public class APLedgerJournalCashDepositsRequest
    {
        public string PreparationDate { get; set; }//TransDate
        public string DateCollection { get; set; }//TransDate
        public string CollectionEntry { get; set; }
        public decimal CollectionAmount { get; set; }
        public string PaymentCollection { get; set; }
        public string Bank { get; set; }
        public string DepositNumber { get; set; }
        public string UserDeposit { get; set; }
    }
}
