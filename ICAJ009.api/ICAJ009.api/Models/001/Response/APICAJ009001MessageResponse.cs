using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ009.api.Models._001.Response
{
    public class APICAJ009001MessageResponse
    {
        public List<APCustInvoiceServiceResponse> APCustInvoiceServiceResponseList { get; set; } //Listado de facturas de servicios
        public string StatusId { get; set; } // Estado del registro 1=OK; 0=ERROR
        public List<string> ErrorList { get; set; } //Detalle del error
    }

}
