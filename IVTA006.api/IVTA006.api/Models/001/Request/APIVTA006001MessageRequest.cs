using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVTA006.api.Models._001.Request
{
    public class APIVTA006001MessageRequest
    {
        public string Enviroment { get; set; }
        public APInvoiceIVTA006001[] APInvoiceList { get; set; }
        public string SessionId { get; set; }
        public string DataAreaId { get; set; }

    }
}
