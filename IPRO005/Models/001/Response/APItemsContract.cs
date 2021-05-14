using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO005.api.Models._001.Response
{
    public class APItemsContract
    {
        public string ItemId { get; set; }
        public APRelatedProductsContract[] APRelatedProductsContract { get; set; }
    }
}
