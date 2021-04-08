using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ015.api.Models.Response
{
    public class APICAJ015001MessageResponse
    {
        public Guid SesionId { get; set; }
        public string DescriptionId { get; set; }
        public string[] ErrorList { get; set; }
        public List<APFinancialPlanICAJ015001> FinancialPlanList { get; set; }
    }
}
