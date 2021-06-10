using System;
using System.Collections.Generic;
using System.Text;

namespace ILOG002.Models._002.Response
{
    public class APILOG002002MessageResponse
    {
        public string SessionId { get; set; }
        public Boolean DescriptionId { get; set; }
        public string[] ErrorList { get; set; }
        public List<APPackageShippifyResponse> PackageShippifyId { get; set; }
    }
}
