using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO005.api.Models._007.Request
{
    public class APIPRO005007MessageRequest
    {
        public string DataAreaId { get; set; }
        public string SessionId { get; set; }
        public string Enviroment { get; set; }
        public string ItemId { get; set; }
        public string[] InventLocationList { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

    }
}
