using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.Api.Models.IVTA011002.Request
{
    public class APCustInvoiceLineLegado
    {
        // 002 Ventas MULTINOVA (Contado/Crédito y las Devoluciones) 
        public string ItemId { get; set; }//Articulo
        public decimal Qty { get; set; }//cantidad
        public string ItemName { get; set; }//Descripcion
        public decimal Amount { get; set; }//Monto
        public string InvoiceId { get; set; }//factura
        public List<APFinancialDimension> APFinancialDimensionList { get; set; }//Listado de dimensiones financieras

    }
}
