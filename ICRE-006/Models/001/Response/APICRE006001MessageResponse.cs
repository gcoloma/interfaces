using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICRE006.Models._001.Response
{
    public class APICRE006001MessageResponse
    {
        public string AccountNum { get; set; } 
        public Type Type { get; set; }
        public string FistName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public IdentificationType IdentificationType { get; set; }
        public string VATNum { get; set; }
        public string OrganizationName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CustGroup { get; set; }
        public DateTime CustomerSince { get; set; }
        public string IndependentEntrepreneurId { get; set; }
        public List<APLogisticsPostalAddress> LogisticsPostalAddress { get; set; }
        public List<APContactInfo> ContactInfoList { get; set; }
        public string SessionId { get; set; }


    }
    public enum Type { persona=1,organizacion=2}
    public enum IdentificationType { Ninguno=0,RUC=1,Cedula=2,Pasaporte=3,Consumidor_final=4}
}
