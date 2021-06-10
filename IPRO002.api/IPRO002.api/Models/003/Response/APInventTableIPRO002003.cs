using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO002.api.Models._003.Response
{
    public class APInventTableIPRO002003
    {
        public string ItemId { get; set; }        
        public string ProductType { get; set; }
        public string IKD { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public List<APInventTableLMATIPRO002003> APInventTableList { get; set; }
    }
}
