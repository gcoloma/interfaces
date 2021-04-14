using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVTA014.api.Models._002.Request
{
    public class APCustSettlementIVTA014002
    {

        public string InvoiceId { get; set; } //Factura
        public string Voucher { get; set; } // ID de asiento
        public string InvoiceDate { get; set; } // Fecha de la factura
        public string CustAccount { get; set; } // Código de cliente
        public string BusinessUnit { get; set; } // Unidad de negocio
        public string WorkSalesResponsibleCode { get; set; } //Código de Vendedor
        public string WorkSalesResponsibleName { get; set; } //Nombre del vendedor
        public Decimal AmountCuota { get; set; } // Monto Cuota
        public Decimal AmountRecaudo { get; set; } // Valor recaudo
        public DateTime DueDate { get; set; } //Fecha de vencimiento
        public DateTime DateRecaudo { get; set; } // Fecha de recaudo
        public Boolean StatusRegister { get; set; } // Ok éxito / false error
        public String MessageError { get; set; } // Error

                 
    }
}
