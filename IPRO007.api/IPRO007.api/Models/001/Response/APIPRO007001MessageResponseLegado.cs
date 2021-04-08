using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO007.api.Models._001.Response
{
    public class APIPRO007001MessageResponseLegado
    {
        public string SessionId { get; set; }//Id de sesión //Guid

        public string Descripcion { get; set; }//descripcion ok/error

        public List<APIPRO007001Error> ErrorList { get; set; }//Listado de grupo Cliente

    }
}
