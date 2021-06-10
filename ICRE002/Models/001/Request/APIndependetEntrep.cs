using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE002.api.Models
{
    public class APIndependetEntrep
    {
        public string APCodeIndependent { get; set; }//Código NETZEN
        public DateTime DateStartRelation { get; set; }//Fecha de inicio de relación
        public DateTime DateEndRelation { get; set; }//Fecha fin de relación
        public APRelationStatus APRelationStatus { get; set; }//Estado de la relación
        public string AccountNum { get; set; }//Código del Cliente
        public string VATNum { get; set; }//Número de identifica
        public DateTime DateEntryReq { get; set; }//Fecha de ingreso de solitud
    }
    public enum APRelationStatus {valor =1}//OJO
}
