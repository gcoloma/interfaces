using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAC017.api.Models._001.Request
{
    public class APISAC017001MessageRequest
    {
        public string DataAreaId { get; set; }
        public string SessionId { get; set; } 
        public string Enviroment { get; set; }                               
        public APSalesTableReturn ReturnTable { get; set; }
    }
}
