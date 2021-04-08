using ICRE007.api.Models._002.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE007.api.Models._002.Response
{
    public class APICRE007002MessageResponse
    {
        public Guid SessionId { get; set; }//Id de sesión
        public List<APPostingProfile> APPostingProfileList { get; set; }//Listado de grupo Cliente

    }
}
