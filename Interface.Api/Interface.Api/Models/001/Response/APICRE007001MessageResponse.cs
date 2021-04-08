using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.Api.Models.ICRE007001.Request
{
    public class APICRE007001MessageResponse
    {
        public Guid SessionId { get; set; }//Id de sesión
        public APCustGroup APCustGroupList { get; set; }//Listado de grupo Cliente

    }
}
