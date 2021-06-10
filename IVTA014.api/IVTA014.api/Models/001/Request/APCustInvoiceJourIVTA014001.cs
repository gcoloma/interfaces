using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVTA014.api.Models._001.Request
{
    public class APCustInvoiceJourIVTA014001
    {
        public string InvoiceId { get; set; } //Factura
        public string Voucher { get; set; } // ID de asiento
        public string InvoiceDate { get; set; } // Fecha de la factura
        public string CustAccount { get; set; } // Código de cliente
        public string BusinessUnit { get; set; } // Unidad de negocio
        public List<APCustInvoiceTransIVTA014001> APCustInvoiceTransList { get; set; } // Listado de lineas
        public Boolean StatusRegister { get; set; } // Ok éxito / false error
        public string MessageError { get; set; } // Error



    }
}
