using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE001.Models
{
    public class APICRE001002MessageResponse
    {
        public Guid SessionId { get; set; }
        public APIndependetEntrepICRE001002 APIndependetEntrep { get; set; }
        public Boolean StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
