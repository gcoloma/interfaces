using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.Api.Models.ISAC001001.Response
{
    public class APISAC001001MessageResponse
    {
        public Guid SessionId { get; set; }//Id de sesión
        public string DescriptionId { get; set; }//Descripción trnsaccion
        public List<string> ErrorList { get; set; }//Detalle del error
    }
}
