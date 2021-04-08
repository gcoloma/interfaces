using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.Api.Models.IVTA011002.Request
{
    public class APIVTA011002MessageRequest
    {
        // 002 Ventas MULTINOVA (Contado/Crédito y las Devoluciones) 
        public string DataAreaId { get; set; }//Id de la compañia
        public string Enviroment { get; set; }//entorno
        public Guid SessionId { get; set; }//Id de sesión
        public List<APCustInvoiceHeader> ApCustInvoiceHeaderList { get; set; }//Listado de ventas facturadas Multinova
       
    }
}
