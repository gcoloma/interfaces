using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE001.Models
{
    public class APCustTableICRE001001
    {
        public Type Type { get; set; }
        public string AccountNum { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string NameAlias { get; set; }
        public string NameOrganization { get; set; }
        public string NameAliasOrganization { get; set; }
        public string CustGroup { get; set; }       
        public int BirthDay { get; set; }
        public MonthsOfYear BirthMonth { get; set; }
        public int BirthYear { get; set; }
        public string Taxgroup { get; set; }
        public DateTime CustomerSince { get; set; }
        public string LanguageId { get; set; }
        public string Currency { get; set; }
        public string TaxVATNum { get; set; }
        public APTaxVATNumTable APTaxVATNumTable { get; set; }        
        public List<APLogisticsPostalAddressICRE001001> APLogisticsPostalAddressList { get; set; }
        public List<APContactInfoICRE001001> APContactInfoList { get; set; }
        public APIndependetEntrepICRE001001 APIndependetEntrep { get; set; }
        public List<APFinancialDimension> APFinancialDimensionList { get; set; }

    }
    public enum Type { Persona = 1, Organizacion = 2 }
    public enum MonthsOfYear { Enero = 1, Febrero = 2, Marzo = 3, Abril = 4, Mayo = 5, Junio = 6, Julio = 7, Agosto = 8, Septiembre = 9, Octubre = 10, Noviembre = 11, Diciembre = 12 }
}
