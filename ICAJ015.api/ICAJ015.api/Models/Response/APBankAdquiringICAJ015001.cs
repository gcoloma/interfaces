using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ015.api.Models.Response
{
    public class APBankAdquiringICAJ015001
    {
        public string BankAcquiringId { get; set; }
        public string DescriptionBankAcquiring { get; set; }
        public Int32 MonthsTerms { get; set; }
        public double FinancialRate { get; set; }
    }
}
