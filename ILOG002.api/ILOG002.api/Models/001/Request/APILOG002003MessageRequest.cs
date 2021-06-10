using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILOG002.api.Models
{
    public class APILOG002003MessageRequest
    {
        public string DataAreaId { get; set; }
        public string Enviroment { get; set; }
        public string SessionId { get; set; }
        public List<APPackageShippifyRequest> PackageShippifyList { get; set; }
    }
}
