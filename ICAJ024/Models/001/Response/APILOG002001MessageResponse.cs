using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ024.api.Models._001.Response
{
    public class APILOG002001MessageResponse
    {
        public Guid SessionId { get; set; }
        public bool DescriptionId { get; set; }
        public string[] ErrorList { get; set; }
        public string NumDebitNote { get; set; }
        public string VoucherDebitNote { get; set; }
        public DateTime DateDebitNote { get; set; }
        public APDocumentCreditNoteResponse[] DocumentCreditNoteList { get; set; }
    }
}
