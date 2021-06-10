using System;
using System.Collections.Generic;
using System.Text;

namespace ILOG002.Models._001.Response
{
    public class APILOG002001MessageResponse
    {
        public string SessionId { get; set; }
        public Boolean DescriptionId { get; set; }
        public string[] ErrorList { get; set; }
        public List<APSendShippifyResponse> SendShippifyList { get; set; }
    }
}
