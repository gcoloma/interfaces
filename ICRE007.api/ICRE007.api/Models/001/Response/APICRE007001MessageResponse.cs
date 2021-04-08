using ICRE007.api.Models._001.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE007.api.Models._001.Response
{
    public class APICRE007001MessageResponse
    {
        public Guid SessionId { get; set; }//Id de sesión
        public APCustGroup APCustGroupList { get; set; }//Listado de grupo Cliente

    }
}
