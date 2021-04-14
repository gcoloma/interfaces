using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ009.api.Models._001.Request
{
    public class APCustInvoiceServicesLineContract
    {
        public String NumLine { get; set; } //Linea
        public Decimal Qty { get; set; } //Cantidad
        public Decimal Amount { get; set; } //Monto

    }
}
