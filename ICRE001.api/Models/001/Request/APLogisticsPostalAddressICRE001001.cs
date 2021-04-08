using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE001.Models
{
    public class APLogisticsPostalAddressICRE001001
    {
        public string Description { get; set; }
        public string Role { get; set; }
        public Boolean IsPrimary { get; set; }
        public string CountryRegionId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public List<APContactInfoICRE001001> APContactInfoList { get; set; }
        public Int64 RecId { get; set; }
    }
}
