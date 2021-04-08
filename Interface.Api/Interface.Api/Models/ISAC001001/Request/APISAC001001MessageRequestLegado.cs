using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.Api.Models.ISAC001001.Request
{
    public class APISAC001001MessageRequestLegado
    {
        public string DataAreaId { get; set; }//Id de la compañía 

        public int prioridad { get; set; }//Prioridad 

        public string SessionId { get; set; }//Id de sesión tipo Guid
        public List<CCENTAssetObjectTable> APENTAssetObjectTableList { get; set; } //Listado de Activos
    }
}
