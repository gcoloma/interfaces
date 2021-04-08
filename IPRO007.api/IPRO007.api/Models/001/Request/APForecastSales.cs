using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO007.api.Models._001.Request
{
    public class APForecastSales
    {
        public string ItemId { get; set; } //codigo de articulo
        public string SalesQty { get; set; } //cantidad de ventas
        public DateTime StartDate { get; set; } //fecha
        public string InventLocationId { get; set; } // almacen
        public string WHSInventStatusId { get; set; } //Estado dle inventario /unidad de negocio
        public string EcoResItemStyleName { get; set; } // estilo
    }
}
