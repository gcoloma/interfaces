using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ015.api.Models
{
    public class APICAJ015001MessageRequest
    {
        public string DataAreaId { get; set; }
        public string Enviroment { get; set; }       
        //public Guid SesionId { get; set; }
        public string SesionId { get; set; }        
        public string BusinessUnit { get; set; }
        public string Channel { get; set; }
        public DateTime TransDate { get; set; }

    }
}
