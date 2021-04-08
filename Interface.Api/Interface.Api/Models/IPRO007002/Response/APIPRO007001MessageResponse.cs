using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.Api.Models.IPRO007002.Response
{
    public class APIPRO007001MessageResponse
    {
        public string SessionId { get; set; }//Id de sesión //Guid

        public List<APForecastSales> APForecastSalesList { get; set; }//Listado de grupo Cliente

    }
}
