using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.Api.Models.IPRO007002
{
    public class APForecastSales
    {
        public string MonthOfYear { get; set; } //codigo de articulo
        public string SalesQty { get; set; } //cantidad de ventas
        public string InventLocationId { get; set; } // almacen
        public string WHSInventStatusId { get; set; } //Estado del inventario /unidad de negocio
        public DateTime StartDate { get; set; } //fecha

    }
    public enum Priorodad { enero=1,febrero=2, marzo=3, abril=4, mayo=5,junio=6 ,julio=7,agosto=8, septiembre=9,octubre=10,noviembre=11,diciembre=12}

}
