using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO012.Models._003
{
    public class APIPRO012003MessageRequest
    {
        public string DataAreaId { get; set; }
        public string Enviroment { get; set; }
        public string SessionId { get; set; }
        public string[] ItemIdList { get; set; }
        public string[] BusinessUnit { get; set; }
    }
}
