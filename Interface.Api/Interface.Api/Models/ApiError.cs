using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.Api.Models
{
    public class ApiError
    {
        public string CodigoError { get; set; }
        public string Infraestructura { get; set; }
        public string TituloError { get; set; }
        public string DetalleError { get; set; }
    }
}
