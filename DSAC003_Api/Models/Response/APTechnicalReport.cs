using System.ComponentModel.DataAnnotations;

namespace DSAC003.Api.Models.Response
{
    //Class APTechnicalReport (Proveedores) / (APDSAC003001MessageResponse)
    public class APTechnicalReport
    {
        [Required]
        [StringLength(20)]
        public string WorkOrderNumber { get; set; }

        public string AssetNumber { get; set; }

        public string ItemCode { get; set; }

        public string SerialNumber { get; set; }

        public string ReportType { get; set; }

        public string Discount { get; set; }
        
    }
}


