using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICOB004.api.Models._001.Request
{
    public class APDocumentNCRequest
    {
        public string APIdentificationList { get; set; }//Identificador de lista
        public string CustAccount { get; set; }//Código del cliente
        public DateTime TransDate { get; set; }//Fecha de emisión de la nota de crédito
        public string NumberSequenceGroup { get; set; }//Conjunto de secuencia numérica
        public string DocumentApplies { get; set; }//Número de documento que aplica
        public string PostingProfile { get; set; }//Perfil contable
        public string APRubroSIAC { get; set; }//Rubro SIAC
        public Decimal Qty { get; set; }//Cantidad
        public Decimal PriceUnit { get; set; }//Precio unitario
        public Decimal Neto { get; set; }//Monto neto
        public string MotiveNC { get; set; }//Motivo de la NC


    }
}
