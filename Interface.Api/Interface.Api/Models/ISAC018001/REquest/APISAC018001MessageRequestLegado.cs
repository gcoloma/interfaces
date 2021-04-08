using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.Api.Models.ISAC018001.REquest
{
    public class APISAC018001MessageRequestLegado
    {
        public string custAccount { get; set; }//codigo de cliente

        public string vatNum { get; set; }//identificacion de cliente 

        public string creditNoteNum { get; set; }//numero de la nota de credito

        public DateTime creditNoteDate { get; set; } //fecha nota de credito
        public float creditNoteAmount { get; set; } //monto total de nota de credito
        public string returnNum { get; set; } //numero de orden de devolucion
        public string invoiceNum { get; set; } //factura origen
        public string reasonRefund { get; set; } //motivo de nota de credito
        public List<APItemReturnISAC018001> itemReturnList { get; set; } //Listado codigo de disposición
    }
}
