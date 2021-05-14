using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE002.api.Models._002.Request
{
    public class APContactInfo2
    {
        public string Description { get; set; }//Nombre ó descripción del contacto
        public Type type { get; set; }//Tipo de información
        public string locator { get; set; }//Correspondiente a la información del tipo seleccionado (ejm. Correo, teléfono)
        public string Extension { get; set; }//Código de país
        public bool IsPrimary { get; set; }//Identificador de si es información principal o no
        public Int64 RecId { get; set; }//Identificador único
    }
    //public enum TypeAPContactInfo
    //{
    //    telefono = 1,
    //    direccion_de_correo_electronico = 2,
    //    URL = 3,
    //    Telex = 4,
    //    fax = 5,
    //    facebook = 6,
    //    twitter = 7,
    //    LinkedIn = 8

    //}
}
