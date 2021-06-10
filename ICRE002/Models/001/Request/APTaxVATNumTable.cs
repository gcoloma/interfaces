using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE002.api.Models
{
    public class APTaxVATNumTable
    {
        public string CountryRegionId { get; set; }//Código País
        public APECIdentificationType IdentificationType { get; set; }//Tipo de Identificación
        public string VATNum { get; set; }//Valor
        public string Name { get; set; }//Nombre de la empresa
        public APECTypePerson TypePerson { get; set; }//Natual o Juridica
        public bool RelatedParty { get; set; }//Parte relacionada
    }
    public enum APECIdentificationType { RUC=1,CD=2,PassaPort=3,CF=4}
    public enum APECTypePerson { Natural=1,Legal=2}
}
