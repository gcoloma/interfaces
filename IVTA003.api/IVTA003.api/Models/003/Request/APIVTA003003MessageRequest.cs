using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVTA003.api.Models._003.Request
{
    public class APIVTA003003MessageRequest
    {
        public string DataAreaId { get; set; }
        public string Enviroment { get; set; }
        public string SessionId { get; set; }
        public string[] ListItemId { get; set; }
        public string BusinessUnit { get; set; }
        public string InventSerialId { get; set; }
        public string Mark { get; set; }
        public string ItemName { get; set; }
        public string InventLocationId { get; set; }
        public int LineCategory { get; set; }
        public int GroupCategory { get; set; }
        public int SubgroupCategory { get; set; }
        public int CapacityCategory { get; set; }

    }
}
