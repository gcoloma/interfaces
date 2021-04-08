using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAC001.api.Models._001.Request
{
    public class APISAC001001MessageRequest
    {

        public string DataAreaId { get; set; }//Id de la compañía 

        public Prioridad prioridad { get; set; }//Prioridad 

        public Guid SessionId { get; set; }//Id de sesión

        public List<APENTAssetObjectTable> APENTAssetObjectTableList { get; set; } //Listado de Activos

    }
    public enum Prioridad { Bajo = 0, Medio = 1, Alto = 2 }
}
