﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE001.Models
{
    public class APIndependetEntrepICRE001002
    {
        public string APCodeIndependentVend { get; set; }
        public string VATNum { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }       
        public DateTime DateEntryIndependetEntrep { get; set; }
        public APRelationStatus APRelationStatus { get; set; }
        public APBlocked APBlocked { get; set; }
        public string APCodeReason { get; set; }
        public string APDescriptionReason { get; set; }
        public DateTime DateBlockTmpFrom { get; set; }
        public DateTime DateBlockTmpTo { get; set; }
        public string CodeParent { get; set; }
        public DateTime DateParent { get; set; }
        public DateTime DateDown { get; set; }
        public List<APContactInfoICRE001002> APContactInfoList { get; set; }

    }
    public enum APBlocked { T = 0, P = 1 }
}