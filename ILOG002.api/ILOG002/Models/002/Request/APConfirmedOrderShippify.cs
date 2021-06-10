using System;
using System.Collections.Generic;
using System.Text;

namespace ILOG002.Models._002.Request
{
    public class APConfirmedOrderShippify
    {
        public string PackageShippifyId { get; set; }
        public string NumDocument { get; set; }
        public string TypeDelivery { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal Qty { get; set; }
        public decimal Weight { get; set; }
        public string Size { get; set; }
        public string ApprovedPending { get; set; }
        public string CodeRoute { get; set; }
        public string Status { get; set; }
        public string DriverIdentification { get; set; }
        public string DriverName { get; set; }
        public string LicensePlate { get; set; }
        
    }
}
