using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ008.api.Models._001.Response
{
    public class APDocumentInvoiceRequestLinesICAJ008001
    {
        public string Voucher { get; set; }//Id del asiento de la factura
        public string InvoiceId { get; set; }//Numero de la factura
        public string ItemId { get; set; }//Código del producto
        public int Qty { get; set; }//Cantidad
        public string InvoiceDate { get; set; }//Fecha de emisión de la factura, Date
        public decimal TotalAmount { get; set; }//Total de cada factura


    }
}
