using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVTA014.api.Models._001.Request
{
    public class APCustInvoiceTransIVTA014001
    {
        public string itemId { get; set; } //Código de Articulo
        public Decimal Qty { get; set; } // Cantidad
        public Decimal APPO { get; set; } //PO
        public Decimal APPVP { get; set; } // PVP
        public Decimal LineAmount { get; set; } // Monto total de linea sin IVA incluido descuentos
        public Decimal LineMargen { get; set; } // Margen de linea de factura
        public String InvoiceIdReturn { get; set; } // Número de factura ralacionada a NC
        public DateTime InvoiceDateReturn { get; set; } // Fecha de emisión de factura relacionada NC
        public String PackingGroupId { get; set; } // Marca de articulo / Conjunto de Embalaje
        public String APCodeLines { get; set; } // Linea de articulo
        public String APCodeGroup { get; set; } // Grupo de articulo
        public String APCodeSubGroup { get; set; } // Subgrupo de articulo
        public String APCodeCapacity { get; set; } // Capacidad de articulo
        public String PayMode { get; set; } // Forma de Pago
        public String WorkSalesResponsibleCode { get; set; } // Codigo de Vendedor
        public String WorkSalesResponsibleName { get; set; } // Nombre de Vendedor
        public Decimal Payment { get; set; } //Condicion de pago








    }
}
