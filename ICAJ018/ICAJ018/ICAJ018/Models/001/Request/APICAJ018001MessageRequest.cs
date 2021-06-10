using System;
using System.Collections.Generic;
using System.Text;

namespace ICAJ018.Models._001.Request
{
    class APICAJ018001MessageRequest
    {
        public string DataAreaId { get; set; }
        public string Enviroment { get; set; }
        public string SessionId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string[] VoucherList { get; set; }
        public string[] DocumentNumList { get; set; }
        public string[] StoreList { get; set; }
        public string[] CashList { get; set; }       
    }
}
