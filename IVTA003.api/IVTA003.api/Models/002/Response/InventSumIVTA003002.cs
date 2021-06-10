using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVTA003.api.Models._002.Response
{
    public class InventSumIVTA003002
    {
        public string Style { get; set; }
        public string Company { get; set; }
        public string InventLocationId { get; set; }
        public string InventLocationName { get; set; }
        public string WMSLocationId { get; set; }
        public string WHSLocProfileId { get; set; }
        public int AvailablePhysical { get; set; }
        public string InventSerialId { get; set; }
        public Boolean Color { get; set; }
        public Boolean Year { get; set; }
        public int Cost { get; set; }
        public string BusinessUnit { get; set; }
    }
}
