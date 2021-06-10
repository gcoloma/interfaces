using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVTA004.api.Models._001.Request
{
    public class APSalesLineIVTA004001
    {
        public string ItemId { get; set; }
        public string InventSerialId { get; set; }
        public string configId { get; set; }
        public string TAMFundID { get; set; }
        public string APComboPromotionId { get; set; }
        public decimal APContributionValue { get; set; }
        public string APUserCreateCombo { get; set; }
        public string APPrimarySecondary { get; set; }
        public int APComboPromotionQtyLimit { get; set; }
        public DateTime APComboPromotionStartDate { get; set; }
        public DateTime APComboPromotionEndDate { get; set; }
        public decimal APPromotionPO { get; set; }
        public string InventLocationId { get; set; }
        public string WmsLocationId { get; set; }
        public string InventStatusID { get; set; }
        public DateTime ReceiptDateRequested { get; set; }
        public bool APHomeDelivery { get; set; }
        public DateTime APInstallationDate { get; set; }
        public decimal Qty { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal APSalesCost { get; set; }
        public decimal APSalesPriceOfert { get; set; }
        public decimal APPromotionDiscount { get; set; }
        public decimal APComboDiscount { get; set; }
        public decimal APPaymModeDiscount { get; set; }
        public decimal APInventLocationIdDiscount { get; set; }
        public decimal APTermDiscount { get; set; }
        public decimal APInitialFeeDiscount { get; set; }
        public decimal LineDisc { get; set; }
        public string DataAreaIdStockOwn { get; set; }
        public string InventLocationIdStock { get; set; }
        public string WmsLocationIdStock { get; set; }
        public string APSalesNumberAF { get; set; }
        public string ItemIdAF { get; set; }
        public APFinancialDimension[] APFinancialDimensionList { get; set; }


    }
}
