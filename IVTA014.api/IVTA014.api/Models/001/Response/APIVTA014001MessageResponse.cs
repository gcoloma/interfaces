using IVTA014.api.Models._001.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVTA014.api.Models._001.Response
{
    public class APIVTA014001MessageResponse
    {
        public string SessionId { get; set; } //Guid . Id de sesion
        public List<APCustInvoiceJourIVTA014001> APCustInvoiceJourList { get; set; } // ID de asiento
        public string StatusId { get; set; } // Estado true = ok y False = Error
        public List<string> CustAccount { get; set; } // Listado de errores
    }
}
