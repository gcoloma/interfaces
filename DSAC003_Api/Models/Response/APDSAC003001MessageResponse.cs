using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSAC003.Api.Models.Response
{
    //Class APDSAC003001MessageResponse
    
    public class APDSAC003001MessageResponse
    {
        public string SesionId { get; set; }
        
        public List<APTechnicalReport> APInventTableList { get; set; }
    }
}
