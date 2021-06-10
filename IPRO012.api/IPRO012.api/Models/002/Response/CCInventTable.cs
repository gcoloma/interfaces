using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRO012.Models._002
{
    public class CCInventTable
    {
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public string PackingGroupId { get; set; }
        public string APCodeLines { get; set; }
        public string APCodeGroup { get; set; }
        public string APCodeSubGroup { get; set; }
        public string APCodeCapacity { get; set; }
        public Boolean TaxIVA { get; set; }
        public Boolean ApplyHomeDelivery { get; set; }
        public Boolean ApplyInstallation { get; set; }
        public Boolean IsProductMotorcycle { get; set; }
        public Boolean ApplySerie { get; set; }
        public Boolean IsConsignment { get; set; }
        public Boolean IsMarketplace { get; set; }
        public string LifeCycleStateId { get; set; }
        public Boolean ApplyExtendedWarranty { get; set; }
        public Boolean IsProductAsistenciaFacilita { get; set; }
        public string Origin { get; set; }
        public Boolean IsActiveForPlanning { get; set; }
        public string EcoResProductDimensionGroupName { get; set; }
    }
}
