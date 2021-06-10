using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICOB003.api.Models._002.Response
{
    public class APICOB003002MessageResponse
    {
        public string APIdentificationList { get; set; }//Identificador de lista
        public string Voucher { get; set; }//ID asiento
        public string InvoiceId { get; set; }//Número de factura
        public string StatusId { get; set; }//Estado true = ok y False = Error Boolean 
        public List<string> ErrorList { get; set; }//Listado de errores
       


    }
}
