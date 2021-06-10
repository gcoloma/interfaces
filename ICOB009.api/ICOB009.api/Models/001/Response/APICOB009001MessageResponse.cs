using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICOB009.api.Models._001.Response
{
    public class APICOB009001MessageResponse
    {
        public Guid SessionId { get; set; }        
        public Boolean StatusId { get; set; }
        public string[] ErrorList { get; set; }
        public APDationResponse[] APDationResponse { get; set; }
    }
}
