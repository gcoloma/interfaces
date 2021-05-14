using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVTA005.api.Models._001.Request
{
    public class APIVTA005001MessageRequest
    {
        public string salesId { get; set; }
        public string customerRef { get; set; }
        public string DataAreaId { get; set; }
        public string Enviroment { get; set; }
        public string SessionId { get; set; }
    }
}
