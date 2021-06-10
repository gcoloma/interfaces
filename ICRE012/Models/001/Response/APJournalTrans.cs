using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE012.api.Models._001.Response
{
    public class APJournalTrans
    {
        public DateTime TransDate { get; set; }
        public string voucher { get; set; }
        public string dataAreaId { get; set; }
        public string CustAccount { get; set; }
        public string CustName { get; set; }
        public string txt { get; set; }
        public string[] InvoiceIdList { get; set; }
        public decimal Amount { get; set; }
        public string PaymMode { get; set; }
        public string PostingProfile { get; set; }
        public string APStoreId { get; set; }
        public string APStoreName { get; set; }
        public string UserCreation { get; set; }
        public string TransactionType { get; set; }
        public string SalesId { get; set; }
        public string NumberOT { get; set; }
        public string CajaCode { get; set; }




    }
}
