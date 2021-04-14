using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ009.api.Models._001.Request
{
    public class APCustInvoiceServicesContract
    {
        public DateTime TransDate { get; set; } //Id de la compañía
        public String NumericalSequence { get; set; } //Conjunto de secuencia numerica
        public string DocumentNumber { get; set; } //Numero de documento que modifica
        public string ReasonSIAC { get; set; } //Motivo SIAC
        public string ReasonNC { get; set; } //Motivo NC
        public string DocumentDate { get; set; } //Fecha de Documentos
        public string CustAccount { get; set; } //Cuenta de cliente
        public string SourceReceipt { get; set; } //Recibo de origen
        public List<APCustInvoiceServicesLineContract> APCustInvoiceServicesLineContractList { get; set; } //Recibo de origen


    }
}
