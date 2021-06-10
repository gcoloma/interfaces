using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVTA003.api.Models._002.Request
{
    public class APIVTA003002MessageRequest
    {
        public string DataAreaId { get; set; }
        public string Enviroment { get; set; }
        public string SessionId { get; set; }
        public string[] ListItemId { get; set; }
        public string Mark { get; set; }
        public string BusinessUnit { get; set; }
      
    }
}
