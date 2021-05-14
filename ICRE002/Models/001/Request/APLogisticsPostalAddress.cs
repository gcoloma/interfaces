using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE002.api.Models
{
    public class APLogisticsPostalAddress
    {
        public string Description { get; set; }//Nombre ó descripción del contacto
        public string Role { get; set; }//Propósito
        public bool IsPrimary { get; set; }//Identificador de si es información principal o no
        public string CountryRegionId { get; set; }//Código de país
        public string State { get; set; }//Código de provincia
        public string City { get; set; }//Código de ciudad.
        public string Street { get; set; }//Número correspondiente a la dirección
        public string StreetNumber { get; set; }//Número de calle
        public APContactInfo[] APContactInfoList { get; set; }//Listado de Contactos
        public Int64 RecId { get; set; }//Identificador único
    }
}
