using System;
using System.Collections.Generic;
using System.Text;

namespace ILOG002.Models._004.Request
{
    public class APILOG002004MessageRequest
    {
        public string DataAreaId { get; set; }
        public string Enviroment { get; set; }
        public string SessionId { get; set; }
        public List<APPackageShippifyCanceledRequest> PackageCanceledRequest { get; set; }
    }
}
