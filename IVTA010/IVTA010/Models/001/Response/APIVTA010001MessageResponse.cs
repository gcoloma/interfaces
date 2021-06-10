using System;
using System.Collections.Generic;
using System.Text;

namespace IVTA010.Models._001.Response
{
    class APIVTA010001MessageResponse
    {
        public string SessionId { get; set; }//Id de sesión
        public string StatusId { get; set; }//Estado true = ok y False = Error
        public List<string> ErrorList { get; set; }//Listado de errores

    }
}
