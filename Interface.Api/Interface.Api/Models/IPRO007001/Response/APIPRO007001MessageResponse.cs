using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.Api.Models.IPRO007001.Response
{
    public class APIPRO007001MessageResponse
    {
        public string  SessionId { get; set; }//Id de sesión //Guid

        public string Descripcion { get; set; }//descripcion ok/error

        public List<APIPRO007001Error> ErrorList { get; set; }//Listado de grupo Cliente

    }
}
