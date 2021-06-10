using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVTA014.api.Models._002.Request
{
    public class APIVTA014002MessageRequest
    {
        public string DataAreaId { get; set; } //Id de la compañía 
        public string Enviroment { get; set; } // Ambiente
        public List<APCustSettlementIVTA014002> APCustSettlemenList { get; set; } // Listado factura 
        public string SessionId { get; set; } //Id de Sesion

    }
}
