using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using duca_gateway;

namespace duca_gateway.Mocks.StoneDc
{
    public class Stone
    {
        public ErrorReport ErrorReport { get; set; }
        public long InternalTime { get; set; }
        public string MerchantKey { get; set; }
        public string RequestKey { get; set; }
        public BoletoTransactionResultCollection[] BoletoTransactionResultCollection { get; set; }
        public string BuyerKey { get; set; }
        public Options Options { get; set; }
        public CreditCardTransactionResultCollection[] CreditCardTransactionResultCollection { get; set; }
        public OrderResult OrderResult { get; set; }
    }
}
