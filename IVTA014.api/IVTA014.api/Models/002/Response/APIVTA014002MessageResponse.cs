using IVTA014.api.Models._002.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVTA014.api.Models._002.Response
{
    public class APIVTA014002MessageResponse
    {
        public string SessionId { get; set; } //Guid . Id de sesion
        public List<APCustSettlementIVTA014002> APCustSettlementList { get; set; } // Listado de recaudos 
        public string StatusId { get; set; } // Estado true = ok y False = Error
        public List<string> ErrorList { get; set; } // Listado de errores
    }
}
