using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE002.api.Models
{
    public class APContactInfo
    {
        
      
        public string Description { get; set; }//Nombre ó descripción del contacto
        public Type_ type { get; set; }//Tipo de información
        public string locator { get; set; }//Correspondiente a la información del tipo seleccionado (ejm. Correo, teléfono)
        public string Extension { get; set; }//Código de país
        public bool IsPrimary { get; set; }//Identificador de si es información principal o no
        public bool facturacion_electronica { get; set; }//Facturación electrónica sí/no
        public Int64 RecId { get; set; }//Identificador único
    }
    public enum Type_
    {
        telefono = 1,
        direccion_de_correo_electronico = 2,
        URL = 3,
        Telex = 4,
        fax = 5,
        facebook = 6,
        twitter = 7,
        LinkedIn = 8

    }
}

