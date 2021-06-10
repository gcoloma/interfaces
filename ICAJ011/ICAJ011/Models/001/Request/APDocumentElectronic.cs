using System;
using System.Collections.Generic;
using System.Text;

namespace ICAJ011.Models._001.Request
{
    class APDocumentElectronic
    {
        public string DocumentNumber { get; set; }
        public string TypeOfDocument { get; set; }
        public string RelatetDocument { get; set; }
        public DateTime DateTimeInterface { get; set; }
        public DateTime DateTimeInterfaceSRI { get; set; }
        public string AuthorizationNumber { get; set; }
        public DateTime DateDocumentRegistration { get; set; }
        public string UserGeneratesInterface { get; set; }//ESTE CAMPO POR PREGUNTAR

    }
}
