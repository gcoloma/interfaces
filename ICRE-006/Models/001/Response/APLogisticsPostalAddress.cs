using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE006.Models._001.Response
{
    public class APLogisticsPostalAddress
    {
        public string Description { get; set; }
        public string Roles { get; set; }
        public bool IsPrimary { get; set; }
        public string CountryRegionId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public List<APContactInfo> ContactInfoList { get; set; }
        public Int64 RecId { get; set; }
    }
}
