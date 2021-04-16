using ICRE_002.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE_003.Models
{
    public class APContactInfo
    {
        
      
        public string Description { get; set; }//Nombre ó descripción del contacto
        public Types type { get; set; }//Tipo de información
        public string locator { get; set; }//Correspondiente a la información del tipo seleccionado (ejm. Correo, teléfono)
        public string Extension { get; set; }//Código de país
        public bool IsPrimary { get; set; }//Identificador de si es información principal o no
        public Int64 RecId { get; set; }//Identificador único
    }
   
}

