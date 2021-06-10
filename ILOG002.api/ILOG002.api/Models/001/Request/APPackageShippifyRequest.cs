using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILOG002.api.Models
{
    public class APPackageShippifyRequest
    {
        public string PackageShippifyId { get; set; }
        public string CodeRoute { get; set; }        
        public StatusEnum StatusShippify { get; set; }
        public string TMSCarrierCode { get; set; }
        public string TMSName { get; set; }
        public string LicensePlate { get; set; }
        public DateTime DateShippify { get; set; }

    }
    public enum StatusEnum { Ninguno = 0, PendienteAprobacion = 1, Aprobado = 2}
}
