using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAC020.Models.ResponseHomologacion
{
    public class ResponseHomologacion
    {
        public int StatusCode { get; set; }//Http Status Code
        public string Response { get; set; }//Codigo Siac
        public string DescripcionId { get; set; }//“OK”, “ERROR”
        public string[] ErrorList { get; set; }//Descripción
    }
}
