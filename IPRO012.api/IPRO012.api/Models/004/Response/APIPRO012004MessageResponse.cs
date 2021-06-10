using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO012.Models._004
{
    public class APIPRO012004MessageResponse
    {
        public Guid SessionId { get; set; }
        public List<CCEcoResCategory> APEcoResCategoryList { get; set; }
    }
}
