using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICXP003.api.Models._001.Request
{
    public class APContactInfo
    {
        public string Description { get; set; }
        public Type Type { get; set; }
        public string Locator { get; set; }
        public string Extension { get; set; }
        public Boolean IsPrimary { get; set; }
        public Boolean Facturacion_electronica { get; set; }
        public APStatusContact APStatusContact { get; set; }
    }
    public enum Type { Telefono = 1, Direccion_de_correo_electronico = 2, URL = 3, TELEX = 4, FAX = 5, Facebook = 6, Twitter = 7, LinkedIn = 8 }
    public enum APStatusContact { Nuevo = 1, actual = 2, modificacion = 3}
}
