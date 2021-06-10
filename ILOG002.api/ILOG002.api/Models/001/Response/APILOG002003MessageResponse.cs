using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILOG002.api.Models._001.Response
{
    public class APILOG002003MessageResponse
    {
        public Guid SessionId { get; set; }        
        public Boolean DescriptionId { get; set; }
        public string[] ErrorList { get; set; }
        public List<APPackageShippifyResponse> PackageShippifyId { get; set; }
    }
}
