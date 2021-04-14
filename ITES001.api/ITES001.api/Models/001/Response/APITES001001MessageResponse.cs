using ITES001.api.Models._001.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITES001.api.Models._001.Response
{
    public class APITES001001MessageResponse
    {
        public string DataAreaId { get; set; }//Id de la compañía 
        public List<APVendTransRegistration> APVendTransRegistrationList { get; set; }//Listado de registros
    }
}
