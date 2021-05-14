using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE008.api.Models._001.Response
{
    public class APSalesTable
    {
        public string CustAccount { get; set; }
        public string SalesId { get; set; }
        public string NumberOrdenRef { get; set; }
        public string APPaymModeSales { get; set; }
        public string WorkSalesResponsible { get; set; }
        public string WorkSalesResponsibleName { get; set; }
        public string APProductFinancialCode { get; set; }
        public string IndependentEntrepreneurId { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal Subtotal { get; set; }
        public decimal totalIVA { get; set; }
        public decimal AmountInvoice { get; set; }



    }
}
