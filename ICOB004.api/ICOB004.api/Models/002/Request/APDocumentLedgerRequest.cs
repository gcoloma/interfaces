using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICOB004.api.Models._002.Request
{
    public class APDocumentLedgerRequest
    {
        public string APIdentificationList { get; set; }//Identificador de lista
        public string CustAccount { get; set; }//Código del cliente
        public DateTime TransDate { get; set; }//Fecha de diario
        public Decimal AmountDebit { get; set; }//Monto débito
        public Decimal AmountCredit { get; set; }//Monto crédito
        public string PostingProfile { get; set; }//Perfil contable
        public string DocumentNegoc { get; set; }//Documento de negociación
       




    }
}
