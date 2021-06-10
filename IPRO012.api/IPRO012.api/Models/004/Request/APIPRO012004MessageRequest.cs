using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO012.Models._004
{
    public class APIPRO012004MessageRequest
    {
        public string DataAreaId { get; set; }
        public string Enviroment { get; set; }
        public string SessionId { get; set; }
        public APProductHierarchyType APProductHierarchyType { get; set; }
    }
    public enum APProductHierarchyType { Linea = 0, Grupo = 2, SubGrupo = 3, Categoria = 4 }
}
