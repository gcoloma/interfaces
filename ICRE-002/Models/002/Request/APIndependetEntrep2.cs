using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE_002.Models._002.Request
{
    public class APIndependetEntrep2
    {
        public string APCodeIndependentVend { get; set; }//Código NETZEN(20)
        public string VATNum { get; set; }//Número de identifica(20)
        public string FistName { get; set; }//Primer nombre del cliente(50)
        public string SecondName { get; set; }//Segundo nombre del cliente(50)
        public string LastName { get; set; }//Apellidos del cliente(100)
        public DateTime DateEntryIndependetEntrep { get; set; }//Fecha de inscripción del Emprendedor Independiente
        public APRelationStatus2 APRelationStatus { get; set; }//Estado de la relación
        public APBlocked APBlocked { get; set; }//Bloqueo
        public int APCodeReason { get; set; }//Motivo
        public string APDescriptionReason { get; set; }//Nombre del motivo
        public DateTime DateBlockTmpFrom { get; set; }//Período de Bloqueo Temporal con Fecha desde
        public DateTime DateBlockTmpTo { get; set; }//Período de Bloqueo Temporal con  Fecha hasta
        public int CodeParent { get; set; }//Código Netzen jerarquía, campo numérico entero
        public DateTime DateParent { get; set; }//Fecha de relacion con el còdigo Padre en formato
        public DateTime DateDown { get; set; }//Fecha y hora de baja
        public List<APContactInfo> APContactInfoList { get; set; }//Listado de Contactos
    }

    public enum APRelationStatus2 { A=0, B=1 }
    public enum APBlocked { T=0, P=1 }
}
