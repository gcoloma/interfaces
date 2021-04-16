using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE_002.Models
{
    public class APICRE002001MessageRequest
    {
      //  Para ejecutar la actualización primero deben consultar información del cliente método definido en el ICRE-006.
        public string DataAreaId { get; set; }//Id de la compañía 
                 
        public string Enviroment { get; set; }
        public Prioridad prioridad { get; set; }//Prioridad 

        public string SessionId { get; set; }//Id de sesión
        
        public APCustTableICRE002001 APCustTable { get; set; } //Objeto Cliente
    }
    public enum Prioridad { Bajo = 0, Medio = 1, Alto = 2 }
}
