using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace duca_gateway.Mocks.StoneDc
{
    public class CreditCard
    {
        public string CreditCardBrand { get; set; }
        public string InstantBuyKey { get; set; }
        public bool IsExpiredCreditCard { get; set; }
        public string MaskedCreditCardNumber { get; set; }
    }
}
