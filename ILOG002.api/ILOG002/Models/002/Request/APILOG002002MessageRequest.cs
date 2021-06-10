using System;
using System.Collections.Generic;
using System.Text;

namespace ILOG002.Models._002.Request
{
    public class APILOG002002MessageRequest
    {
        public string DataAreaId { get; set; }
        public string Enviroment { get; set; }
        public string SessionId { get; set; }
        public List<APConfirmedOrderShippify> ConfirmedShippifyList { get; set; }
    }
}
