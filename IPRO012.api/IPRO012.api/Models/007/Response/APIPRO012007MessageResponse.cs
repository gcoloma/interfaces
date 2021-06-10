using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO012.Models._007
{
    public class APIPRO012007MessageResponse
    {
        public Guid SessionId { get; set; }
        public List<APEcoResProductDimensionGroup> APEcoResProductDimensionGroupList { get; set; }
    }
}
