using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICXP003.api.Models._001.Request
{
    public class APLedgerJournalTransICXP003
    {
        public DateTime TransDate { get; set; }
        public string Credit { get; set; }
        public string Period { get; set; }
        public string BonusTypeId { get; set; }
    }
}
