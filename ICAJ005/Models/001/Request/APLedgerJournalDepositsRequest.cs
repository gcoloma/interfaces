using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ005.Models._001.Request
{
    public class APLedgerJournalDepositsRequest
    {
        public string ConfirmationDate { get; set; }//TransDate
        public string Bank { get; set; }
        public decimal Amount { get; set; }
        public string Cashbox { get; set; }
        public string NoTicket { get; set; }
        public string ConfirmingUser { get; set; }
        public string DepositNumber { get; set; }
        public string DatePreparation { get; set; }//TransDate
    }
}
