using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE012.api.Models._001.Response
{
    public class APSalesTable
    {
        public string CustAccount { get; set; }
        public string SalesId { get; set; }
        public string NumberOrdenRef { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal Subtotal { get; set; }
        public decimal totalIVA { get; set; }
        public decimal AmountInvoice { get; set; }
        public string CustGroup { get; set; }
        public string APStoreId { get; set; }
        public string APStoreName { get; set; }
        public string DescriptionEstablishment { get; set; }
        public string BusinessUnitDimFinOrigin { get; set; }
        public string ReasonIdNC { get; set; }
        public string ReasonDescriptionNC { get; set; }
        public APSalesLine[] APSalesLineList { get; set; }


    }
}
