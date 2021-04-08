using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.Api.Models.IVTA011001.Request
{
    public class APIVTA011001MessageRequestLegado
    {
        // 001 Periodo vigente para multinova
        public string DataAreaId { get; set; }//Id de la compañía 
        public string Enviroment { get; set; }//Entorno
        public Guid SessionId { get; set; }//Id de sesión
        public DateTime TransDate { get; set; }//Fecha de ejecucion
    }
}
