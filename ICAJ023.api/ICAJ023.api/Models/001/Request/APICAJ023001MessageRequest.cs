using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ023.api.Models._001.Request
{
    public class APICAJ023001MessageRequest
    {
        public string DataAreaId { get; set; }//Id de la compañía
        public string Environment { get; set; }//Ambiente Enviroment
        public string SessionId { get; set; }//Id de sesión
        public List<APAccountingStatementContract> APAccountingStatementContractList { get; set; }//Lista del estracto contable


    }
}
