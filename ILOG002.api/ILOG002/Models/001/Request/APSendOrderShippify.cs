using System;
using System.Collections.Generic;
using System.Text;

namespace ILOG002.Models._001.Request
{
    public class APSendOrderShippify
    {
        public string NumDocument { get; set; }
        public string TypeDelivery { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal Qty { get; set; }
        public decimal Weight { get; set; }
        public string Size { get; set; }
        public string DeliveryAddress { get; set; }
        public string AccountNum { get; set; }
        public string AccountName { get; set; }
        public string VatNum { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string SalesOriginId { get; set; }
        public string InventLocationFrom { get; set; }
        public string InventLocationTo { get; set; }
        public decimal AmountTotal { get; set; }
        public string Country { get; set; }
        public string Country2 { get; set; }//repetido
        public string DeliveryAddressFrom { get; set; }
        public string Reprogrammed { get; set; }
        public string Zone { get; set; }
        public string ApprovedPending { get; set; }
        public  LocationWarehouse LocationWarehouse { get; set; }
        public Status Status { get; set; }

    }
    public enum LocationWarehouse { BC = 0, BB = 1}
    public enum Status { Creado = 0, OrdenAbierta = 1, Cancelado = 2 }
}
