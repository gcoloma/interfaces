using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE012.api.Models._001.Response
{
    public class APICRE012001MessageResponse
    {
        public string SessionId { get; set; }
        public APInvoice APInvoice { get; set; }
        public APJournalTable APJournalTable { get; set; }
        public bool StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
