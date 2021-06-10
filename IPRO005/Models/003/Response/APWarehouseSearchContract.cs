using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO005.api.Models._003.Response
{
    public class APWarehouseSearchContract
    {
        public string WarehouseCode { get; set; }
        public string WarehouseDescription { get; set; }
        public APWmsLocationContract[] LocationList { get; set; }
    }
}
