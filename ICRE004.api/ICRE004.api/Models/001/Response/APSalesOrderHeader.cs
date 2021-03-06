using ICRE004.api.Models._001.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE004.api.Models._001.Response
{
    public class APSalesOrderHeader
    {
        public string DataAreaId { get; set; }
        public string SalesId { get; set; }
        public string PurchOrderFormNum { get; set; }
        public string APStoreId { get; set; }
        public string CustAccount { get; set; }
        public string CustName { get; set; }
        public decimal Amount { get; set; }
        public string SalesResponsibleName { get; set; }
        public string SalesResponsiblePersonalNumber { get; set; }
        public string APPaymModeGeneral { get; set; }
        public string APProductFinancialTCCode1 { get; set; }
        public string APProductFinancialCFCode { get; set; }
        public SalesStatus SalesStatus { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
        public string APPromotionalCode { get; set; }
        public decimal APPaymModeCash { get; set; }
        public decimal APPaymModeCF { get; set; }
        public decimal APPaymModeME { get; set; }
        public string APProductFinancialTCCode2 { get; set; }
        public string IndependentEntrepreneurId { get; set; }
        public Boolean APBillBuyer { get; set; }
        public decimal APAmountGeneratBillBuyer { get; set; }
        public Boolean APBillBuyerNC { get; set; }
        public string APBillBuyerProvisionId { get; set; }
        public string APBillBuyerNumber { get; set; }
        public decimal APAmountBillBuyer { get; set; }
        public string PostingProfile { get; set; }
        public string SalesPoolId { get; set; }
        public string SalesOriginId { get; set; }
        public Int64 DeliveryPostalAddressRecId { get; set; }
        public DateTime ConfirmDate { get; set; }
        public List<APSalesLine> APSalesLineList { get; set; }
    }
    public enum SalesStatus { None = 0, Backorder = 1, Delivered = 2, Invoiced = 3, Canceled = 4 }

}
