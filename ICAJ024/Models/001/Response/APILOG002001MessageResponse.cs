using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ024.Models._001.Response
{
    public class APILOG002001MessageResponse
    {
        public string SessionId { get; set; }
        public bool DescriptionId { get; set; }
        public List<string> ErrorList { get; set; }
        public string NumDebitNote { get; set; }
        public string VoucherDebitNote { get; set; }
        public DateTime DateDebitNote { get; set; }
        public List<APDocumentCreditNoteResponse> DocumentCreditNoteList { get; set; }
    }
}
