using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.Api.Models.ICRE007002.Request
{
    public class APICRE007002MessageResponse
    {
        public Guid SessionId { get; set; }//Id de sesión
        public List<APPostingProfile> APPostingProfileList { get; set; }//Listado de grupo Cliente

    }
}
