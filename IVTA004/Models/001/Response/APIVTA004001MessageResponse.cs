using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVTA004.Models._001.Response
{
    public class APIVTA004001MessageResponse
    {
        public string SessionId { get; set; }//Id de sesión
        public string SalesId { get; set; }//Listado de artículos
        public string DescriptionId { get; set; }//Descripción de la transacción EJEMPLO "OK" "ERROR"
        public List<string> ErrorList { get; set; }//Detalle del error
    }
}
