using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE001.Models
{
    public class APIndependetEntrepICRE001001
    {
        public string APCodeIndependentVend { get; set; }
        public DateTime DateStartRelation { get; set; }
        public DateTime DateEndRelation { get; set; }
        public APRelationStatus APRelationStatus { get; set; }
        public string AccountNum { get; set; }
        public string VATNum { get; set; }
        public DateTime DateEntryReq { get; set; }
        public Int64 RecId { get; set; }

    }
    public enum APRelationStatus { A = 0, B = 1 }
}
