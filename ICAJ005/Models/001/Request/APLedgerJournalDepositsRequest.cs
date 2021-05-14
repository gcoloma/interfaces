using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ005.api.Models._001.Request
{
    public class APLedgerJournalDepositsRequest
    {
        public DateTime ConfirmationDate { get; set; }
        public string Bank { get; set; }
        public decimal Amount { get; set; }
        public string Cashbox { get; set; }
        public string NoTicket { get; set; }
        public string ConfirmingUser { get; set; }
        public string DepositNumber { get; set; }
        public DateTime DatePreparation { get; set; }
    }
}
