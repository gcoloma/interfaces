using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE_002.Models
{
    public class APCustTableICRE002001
    {

        public Type_ type { get; set; }//Tipo de cliente en caso de que sea persona u organización
        public string FistName { get; set; }//Primer nombre del cliente
        public string SecondName { get; set; }//Segundo nombre del cliente
        public string LastName { get; set; }//Apellidos del cliente
        public string NameAlias { get; set; }//Nombre Corto
        public string NameOrganization { get; set; }//Nombre de la Organización
        public string NameAliasOrganization { get; set; }//Nombre Corto Organización
        public string CustGroup { get; set; }//Grupo de clientes
        public string LanguageId { get; set; }//dioma
        public DateTime DateOfBirth { get; set; }//Fecha de nacimiento en formato dd/mm/aaaa
        public DateTime CustomerSince { get; set; }//Cliente desde
        public string TaxGroup { get; set; }//Grupo de impuestos sobre la venta
        public APTaxVATNumTable APTaxVATNumTable { get; set; }//Objeto con el Número de identificación fiscal
        public List<APFinancialDimension> APFinancialDimensionList { get; set; }//Listado de dimensiones Financieras
        public List<APLogisticsPostalAddress> APLogisticsPostalAddressList { get; set; }//Listado de direcciones
        public List<APContactInfo> APContactInfoList { get; set; }//Listado de Contactos
        public APIndependetEntrep APIndependetEntrep { get; set; }//Objeto emprendedor independiente
        public string AccountNum { get; set; }//Código del cliente.
        public string VATNum { get; set; }//Número de Identificación cliente
        public string IndependentEntrepreneurId { get; set; }//Código NETZEN

    }  
     
    public enum Type_ { persona = 1, organizacion = 2 }
}

