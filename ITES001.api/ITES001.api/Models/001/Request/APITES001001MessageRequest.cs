using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITES001.api.Models._001.Request
{
    public class APITES001001MessageRequest
    {
        public string DataAreaId { get; set; }//Id de la compañía 

        public List<APVendTransRegistration> APVendTransRegistrationList { get; set; }//Listado de registros

    }
}
