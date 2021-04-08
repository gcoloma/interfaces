using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE001.Models
{
    public class APICRE001001MessageResponse
    {
        public Guid SesionId { get; set; }
        public APCustTableICRE001001 APCustTable { get; set; }
        public string DescriptionId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
