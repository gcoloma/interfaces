﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ020.api.Models._001.Request
{
    public class APICAJ020001MessageRequest
    {
        public string DataAreaId { get; set; } //Id de la compañía 
        public string Enviroment { get; set; } // Id del ambiente
        public string SessionId { get; set; } // Id de sesión
        public List<APDocumentRequestList> DocumentRequestList { get; set; } // Listado de docuemntos a deshacer

    }
    
}
