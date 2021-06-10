using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO005.api.Models._001.Response
{
    public class APRelatedProductsContract
    {
        public string RelationshipType { get; set; }
        public string RelatedProductCode { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
