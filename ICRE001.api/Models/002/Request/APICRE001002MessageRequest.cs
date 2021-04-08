using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE001.Models
{
    public class APICRE001002MessageRequest
    {
        public string DataAreaId { get; set; }
        public string Enviroment { get; set; }
        public EnumPrioridad Prioridad { get; set; }

        //public Guid SesionId { get; set; }
        public string SesionId { get; set; }
        public APIndependetEntrepICRE001002 APIndependetEntrep { get; set; }
    }
    //public enum EnumPrioridad { Bajo = 0, Medio = 1, Alto = 2 }
}
