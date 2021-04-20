using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVTA004.Models._001.Request
{
    public class APSalesLineIVTA004001
    {
        public string ItemId { get; set; }
        public string InventSerialId { get; set; }
        public string configId { get; set; }
        public string TAMFundID { get; set; }
        public string APComboPromotionId { get; set; }
        public double APContributionValue { get; set; }
        public string APUserCreateCombo { get; set; }
        public string APPrimarySecondary { get; set; }
        public int APComboPromotionQtyLimit { get; set; }
        public DateTime APComboPromotionStartDate { get; set; }
        public DateTime APComboPromotionEndDate { get; set; }
        public double APPromotionPO { get; set; }
        public string InventLocationId { get; set; }
        public string WmsLocationId { get; set; }
        public string InventStatusID { get; set; }
        public DateTime ReceiptDateRequested { get; set; }
        public bool APHomeDelivery { get; set; }
        public DateTime APInstallationDate { get; set; }
        public double Qty { get; set; }
        public double SalesPrice { get; set; }
        public double APSalesCost { get; set; }
        public double APSalesPriceOfert { get; set; }
        public double APPromotionDiscount { get; set; }
        public double APComboDiscount { get; set; }
        public double APPaymModeDiscount { get; set; }
        public double APInventLocationIdDiscount { get; set; }
        public double APTermDiscount { get; set; }
        public double APInitialFeeDiscount { get; set; }
        public double LineDisc { get; set; }
        public string DataAreaIdStockOwn { get; set; }
        public string InventLocationIdStock { get; set; }
        public string WmsLocationIdStock { get; set; }
        public string APSalesNumberAF { get; set; }
        public string ItemIdAF { get; set; }
        public List<APFinancialDimension> APFinancialDimensionList { get; set; }


    }
}
