using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ008.api.Models._001.Request
{
    public class APDocumentInvoiceLinesICAJ008001
    {
        public string ItemId { get; set; }//Código del articulo
        public string Serial { get; set; }//Serie del articulo
        public int Qty { get; set; }//Cantidad
        public string PostingProfile { get; set; }//Perfil de contabilización

    }
}
