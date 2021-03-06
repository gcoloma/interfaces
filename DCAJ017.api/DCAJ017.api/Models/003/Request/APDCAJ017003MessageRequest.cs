using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCAJ017.api.Models._003.Request
{
    public class APDCAJ017003MessageRequest
    {
        public string DataAreaId { get; set; }
        public string Enviroment { get; set; }
        public string SessionId { get; set; }
        public string CustAccount { get; set; }
        public string InputCustId { get; set; }
        public string OparationId { get; set; }
        public string CheckStatus { get; set; }
        public string ReasonCode { get; set; }
        public string ReasonDescription { get; set; }
        public APAditionalInformationContract APAditionalInformationContract { get; set; }        
    }
}
