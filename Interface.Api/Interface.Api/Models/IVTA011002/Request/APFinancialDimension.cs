using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.Api.Models.IVTA011002.Request
{
    public class APFinancialDimension
    {
        // 002 Ventas MULTINOVA (Contado/Crédito y las Devoluciones) 
        public string Name { get; set; }//Nombre de la dimension financiera
        public decimal Valor { get; set; }//valor de la dimension financiera
    }
}
