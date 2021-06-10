using IVTA003.api.Models._002.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVTA003.api.Models._003.Response
{
    public class APIVTA003003MessageResponse
    {
        public Guid SessionId { get; set; }
        public List<InventSumIVTA003002> InventSumList { get; set; }
        public Boolean StatusId { get; set; }
        public string[] ErrorList { get; set; }
    }
}
