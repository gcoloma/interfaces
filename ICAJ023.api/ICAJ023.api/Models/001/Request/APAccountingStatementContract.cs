using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ023.api.Models._001.Request
{
    public class APAccountingStatementContract
    {
        public string CashBankId { get; set; }//Código de Caja-Banco
        public string TransDate { get; set; }//Fecha de conciliación , Date
        public string PostingDate { get; set; }//Fecha de registro de la transacción, Date
        public string InventTransId { get; set; }//Asiento
        public string Reference { get; set; }//Referencia
        public string TransTypeSIAC { get; set; }//Tipo de transacción de SIAC
        public decimal Amount { get; set; }//Monto
        public string Sign { get; set; }//(+/-)


    }
}
