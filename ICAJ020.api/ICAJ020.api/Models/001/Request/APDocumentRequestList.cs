﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAJ020.api.Models._001.Request
{
    public class APDocumentRequestList 
    {
        public string CustAccount { get; set; } //Código de cliente
        public string Voucher { get; set; } // Número de asiento principal que se va a deshacer
        public string LastSettlementVoucher { get; set; } // Número de asiento de liquidación que se va a deshacer
        public decimal Amount { get; set; } // Monto
    }
}
