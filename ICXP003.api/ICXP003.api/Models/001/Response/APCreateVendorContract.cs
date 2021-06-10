using ICXP003.api.Models._001.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICXP003.api.Models._001.Response
{
    public class APCreateVendorContract
    {
        public string APCodeIndependentVend { get; set; }
        public string VATNum { get; set; }
        public VendorType VendorType { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FirstNameSearch { get; set; }

    }
    //public enum VendorType2 { Persona = 1, Organizacion = 2 }
}
