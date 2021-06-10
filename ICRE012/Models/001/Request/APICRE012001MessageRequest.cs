using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE012.api.Models._001.Request
{
    public class APICRE012001MessageRequest
    {
        public string DataAreaId { get; set; }
        public string Enviroment { get; set; }
        public string CustAccount { get; set; }
        public DocumentType DocumentType { get; set; }
        public string InvoiceIdFC { get; set; }
        public string InvoiceIdNC { get; set; }
        public string Voucher { get; set; }
        public string APStoreId { get; set; }
        public string BusinnesUnit { get; set; }
        public string ReasonId { get; set; }
        public string TransactionType { get; set; }
        public string PaymMode { get; set; }
        public string CajaCode { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string ItemId { get; set; }
        public string SessionId { get; set; }


    }
    public enum DocumentType { Invoice=0, CreditNote =1, JournalAdvance =2}
}
