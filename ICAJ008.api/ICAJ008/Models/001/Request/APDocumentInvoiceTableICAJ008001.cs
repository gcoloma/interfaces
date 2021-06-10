using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ008.api.Models._001.Request
{
    public class APDocumentInvoiceTableICAJ008001
    {
        public string SalesId { get; set; }//Número de la Orden de Venta
        public string CustAccount { get; set; }//Cuenta del cliente
        public string SalesOrigin { get; set; }//Origen de la venta
        public string InvoiceId { get; set; }//Numero de factura de contingencia
        public string InvoiceDate { get; set; }//Fecha de factura de contingencia, Date
        public string NumberSecuence { get; set; }//Código de Secuencia
        public string DocumentDate { get; set; }//Fecha del documento, Date
        public List<APDocumentInvoiceLinesICAJ008001> DocumentInvoiceLinesList { get; set; }//Listado de líneas de documentos


    }
}
