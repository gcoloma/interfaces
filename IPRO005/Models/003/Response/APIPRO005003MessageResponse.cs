using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO005.api.Models._003.Response
{
    public class APIPRO005003MessageResponse
    {
        public Guid SessionId { get; set; }
        public APWarehouseSearchContract[] APWarehouseSearchContract { get; set; }
        public bool StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
