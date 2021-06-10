using System;
using System.Collections.Generic;
using System.Text;

namespace ILOG002.Models._004.Response
{
    public class APILOG002004MessageResponse
    {
        public string SessionId { get; set; }
        public Boolean DescriptionId { get; set; }
        public string[] ErrorList { get; set; }
        public List<APPackageShippifyCanceledResponsee> PackageCanceledResponse { get; set; }
    }
}
