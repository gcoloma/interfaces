using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ009.api.Models._001.Response
{
    public class APCustInvoiceServiceResponse
    {
        public string IDTransaction { get; set; } //ID. Transacción Voucher String(20)

        public string NumberDocument { get; set; } // No documento InvoiceId String(20)
        public string DocumentApplies { get; set; } //Documento que modifica APECDocumentApplies String(20)

        public Decimal Value { get; set; } // Valor Amount Decimal
        public Decimal LineNumber { get; set; } //numero d elinea LineNum Decimal
        public string LineDescriptions { get; set; } // Descripciones de las líneas ItemFreeTxt String(1000)

        public Decimal LineAmount { get; set; } // Monto de la línea Amount Decimal
        public Decimal TaxAmount { get; set; } // Monto del Impuesto Amount Decimal






    }
}
