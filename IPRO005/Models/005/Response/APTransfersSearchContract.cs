using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO005.api.Models._005.Response
{
    public class APTransfersSearchContract
    {
        public string ProductCode { get; set; }
        public decimal Quantity { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime Dateofshipment { get; set; }
        public string TransferNumber { get; set; }
        public InventTransferStatus Status { get; set; }
        public string Company { get; set; }
    }
    public enum InventTransferStatus
    {
        Created=0,
        Shipped=1,
        Received=2
    }
}
