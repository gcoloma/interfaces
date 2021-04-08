using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.Api.Models.IVTA011001.Response
{
    public class APIVTA011001MessageResponse
    {
        // 001 Periodo vigente para multinova
        public Guid SessionId { get; set; }//Id de sesión
        public DateTime StartDate { get; set; }//Id de la compañía 
        public DateTime EndDate { get; set; }//Entorno
       
    }
}
