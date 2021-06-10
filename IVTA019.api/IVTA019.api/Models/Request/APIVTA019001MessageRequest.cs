using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVTA019.api.Models.Request
{
    public class APIVTA019001MessageRequest
    {
        public string DataAreaId { get; set; }
        public string Enviroment { get; set; }
        public string SessionId { get; set; }
        public string SalesId { get; set; }
        public Boolean hasPurchaserTicket { get; set; }
        public Boolean hasCreditNotePurchaserTicket { get; set; }
        public APPurchaserTicketContract[] PurchaserTicketList { get; set; }
    }
}
