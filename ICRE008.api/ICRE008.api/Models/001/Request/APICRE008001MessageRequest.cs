using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE008.api.Models._001.Request
{
    public class APICRE008001MessageRequest
    {
        public string DataAreaId { get; set; }
        public string Enviroment { get; set; }
        public string CustAccount { get; set; }
        public string InvoiceId { get; set; }
        public string APGroupId { get; set; }
        public string APStoreId { get; set; }
        public string BusinnesUnit { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string SessionId { get; set; }
        public string ItemId { get; set; }
    }
}
