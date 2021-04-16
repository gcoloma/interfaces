using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE_002.Models
{
    public class APTaxVATNumTable
    {
        public string CountryRegionId { get; set; }//Código País
        public IdentificationType IdentificationType { get; set; }//Tipo de Identificación
        public string VATNum { get; set; }//Valor
        public string Name { get; set; }//Nombre de la empresa
        public TypePerson TypePerson { get; set; }//Natual o Juridica
        public bool RelatedParty { get; set; }//Parte relacionada
    }
    public enum IdentificationType { RUC=1,CD=2,PassaPort=3,CF=4}
    public enum TypePerson { Natural=1,Legal=2}
}
