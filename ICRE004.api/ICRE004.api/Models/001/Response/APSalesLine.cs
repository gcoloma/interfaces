using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE004.api.Models._001.Response
{
    public class APSalesLine
    {
        public string APComboPromotionId { get; set; }
        public string TAMFundID { get; set; }
        //public string APComboPromotionId { get; set; } //repetida en el documento
        public decimal APContributionValue { get; set; }
        public string APUserCreateCombo { get; set; }
        public string APItemPrimarySecondary { get; set; }
        public Int32 APComboPromotionQtyLimit { get; set; }
        public DateTime APComboPromotionStartDate { get; set; }
        public DateTime APComboPromotionEndDate { get; set; }
        public decimal APPromotionPO { get; set; }
        public Boolean APHomeDelivery { get; set; }
        public DateTime APInstallationDate { get; set; }
        public decimal APSalesPriceOfert { get; set; }
        public string DataAreaIdStockOwn { get; set; }
        public string InventLocationIdStock { get; set; }
        public string InventLocationDescriptionStock { get; set; }
        public string WmsLocationIdStock { get; set; }
        public string WmsLocationDescriptionStock { get; set; }
        public string APSalesNumberAF { get; set; }
        public string ItemIdAF { get; set; }
        public string APMarginType { get; set; }
        public double APMarginAmount { get; set; }
        public string ItemId { get; set; }
        public string InventSerialId { get; set; }
        public string configId { get; set; }
        public string InventLocationId { get; set; }
        public string InventLocationDescription { get; set; }
        public string WmsLocationId { get; set; }
        public string WmsLocationDescription { get; set; }
        public string InventStatusID { get; set; }
        public DateTime ReceiptDateRequested { get; set; }
        public decimal Qty { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal LineDisc { get; set; }
    }
}
