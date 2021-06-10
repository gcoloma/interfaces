using System;
using System.Collections.Generic;
using System.Text;

namespace IVTA007.Models._001.Response
{
    class APIVTA007001MessageResponse
    {
        public string SessionId { get; set; }
        public APInventTableWebIVTA007001Response[] APInventTableWebResponse { get; set; }
        public Boolean StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
