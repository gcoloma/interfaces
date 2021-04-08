using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.Api.Models.IVTA011002.Request
{
    public class APCustInvoiceHeaderLegado
    {
        // 002 Ventas MULTINOVA (Contado/Crédito y las Devoluciones) 
        public string APStoreId { get; set; }//Tienda
        public string APDocumentType { get; set; }//Tipo de documento
        public string InvoiceId { get; set; }//factura
        public DateTime InvoiceDate { get; set; }//fecha de documento
        public string Nombre { get; set; }//nombre
        public string VatNum { get; set; }//Ruc
        public string APCodeIndependentVend { get; set; }//cedula
        public decimal SubTotalAmount { get; set; }//Monto del subtotal de ventas
        public decimal SubTotalAmountCash { get; set; }//Subtotal al contado
        public decimal SubTotalAmountCredit { get; set; }//Subtotal al credito
        public List<APCustInvoiceLine> ApCustInvoiceHeaderList { get; set; }//Listado de las lineas de factura
    }
}
