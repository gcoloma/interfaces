using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICXP003.api.Models._001.Request
{
    public class APLogisticsPostalAddress
    {
        public string Description { get; set; }
        public Roles Roles { get; set; }
        public Boolean IsPrimary { get; set; }
        public string CountryRegionId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }        
        public string District { get; set; }
    }
    public enum Roles { Invoice = 1, Delivery = 2, Business = 9 }
}
