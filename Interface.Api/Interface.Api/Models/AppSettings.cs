using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.Api.Models
{
    public class AppSettings
    {
        public string RequestConnectionString { get; set; }
        public string RequestQueueName { get; set; }
        public string ResponseConnectionString { get; set; }
        public string ResponseQueueName { get; set; }
    }
}
