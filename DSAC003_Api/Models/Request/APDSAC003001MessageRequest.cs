using System;
using System.ComponentModel.DataAnnotations;

namespace DSAC003.Api.Models.Request
{

    //Parámetros de entrada (APDSAC003001MessageRequest)
    public class APDSAC003001MessageRequest
    {
        public string DataAreaId { get; set; }

        public string SesionId { get; set; }

        public string Environment { get; set; }

        [DataType(DataType.Date)]
        public DateTime ObjectValidFrom { get; set; }
    }
}
