using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO002.api.Models._003.Request
{
    public class APIPRO002003MessageRequest
    {
        public string DataAreaId { get; set; }
        public string Enviroment { get; set; }
        public string SessionId { get; set; }
        public string ItemId { get; set; }
        public string Model { get; set; }
    }
}
