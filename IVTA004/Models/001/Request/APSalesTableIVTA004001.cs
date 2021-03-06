using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVTA004.api.Models._001.Request
{
    public class APSalesTableIVTA004001
    {

        public string PurchOrderFormNum { get; set; }
        public string CustAccount { get; set; }
        public string SalesPoolId { get; set; }
        public string salesOriginId { get; set; }
        public Int64 DeliveryPostalAddress { get; set; }
        public string InventLocationID { get; set; }
        public string WorkSalesResponsibleCode { get; set; }
        public string APPaymModeGeneral { get; set; }
        public string APPromotionalCode { get; set; }
        public string APProductFinancialCFCode { get; set; }
        public string APProductFinancialCFDescription { get; set; }
        public string APProductFinancialTCCode1 { get; set; }
        public string APProductFinancialTCDescription1 { get; set; }
        public decimal APAmountPayModeCash { get; set; }//real
        public decimal APAmountPayModeCredit { get; set; }//real
        public decimal APAmountPayModeElectronic { get; set; }//real
        public string APProductFinancialTCCode2 { get; set; }
        public string APProductFinancialTCDescription2 { get; set; }
        public string IndependentEntrepreneurId { get; set; }
        public string APStoreId { get; set; }
        public bool APBillBuyerCheck { get; set; }
        public decimal APAmountBillBuyer { get; set; }//real
        public bool APBillBuyerCheckNC { get; set; }
        public string PostingProfile { get; set; }
        public APSalesTableBillBuyerNC[] APSalesTableBillBuyerNCList { get; set; }
        public APSalesLineIVTA004001[] APSalesLineList { get; set; }




    }
}
