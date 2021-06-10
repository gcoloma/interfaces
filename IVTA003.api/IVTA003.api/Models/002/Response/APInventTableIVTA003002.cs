using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVTA003.api.Models._002.Response
{
    public class APInventTableIVTA003002
    {
        public string ItemId { get; set; }
        public string Mark { get; set; }
        public string ItemName { get; set; }
        public Boolean Instalation { get; set; }
        public Boolean MarketPlace { get; set; }
        public List<EcoResProductRelationIVTA003002> EcoResProductRelationList { get; set; }
        public List<InventSumIVTA003002> InventSumList { get; set; }
    }
}
