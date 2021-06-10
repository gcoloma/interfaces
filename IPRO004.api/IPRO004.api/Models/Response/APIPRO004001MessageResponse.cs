using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO004.Models
{
    public class APIPRO004001MessageResponse
    {
        public Guid SesionId { get; set; }
        public List<APInventTableIPRO004001> APInventTableList { get; set; }
    }
}
