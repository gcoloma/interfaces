using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE002.api.Models
{
    public class APFinancialDimension
    {
        public string Name { get; set; }//Nombre de la dimensión Financiera
        public string Valor { get; set; }//Valor de la dimensión Financiera
    }
}
