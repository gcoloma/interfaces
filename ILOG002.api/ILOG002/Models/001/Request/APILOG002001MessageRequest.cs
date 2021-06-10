using System;
using System.Collections.Generic;
using System.Text;

namespace ILOG002.Models._001.Request
{
    public class APILOG002001MessageRequest
    {
        public string DataAreaId { get; set; }
        public string Enviroment { get; set; }
        public string SessionId { get; set; }
        public List<APSendOrderShippify> SendShippifyList { get; set; }
    }
}
