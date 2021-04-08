using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE001.Models
{
    public class APTaxVATNumTable
    {
        public string CountryRegionId { get; set; }
        public IdentificationType IdentificationType { get; set; }
        public string VatNum { get; set; }
        public string Name { get; set; }
        public APECTypePerson TypePerson { get; set; }
        public Boolean RelatedParty { get; set; }
    }
    public enum IdentificationType { RUC = 1, CD = 2, Passaport = 3, CF = 4 }
    public enum APECTypePerson { Natural = 1, Legal = 2 }
}
