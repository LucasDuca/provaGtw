using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace duca_gateway.Mocks.ClearSale
{
    public class Payment
    {
        public string Date { get; set; }
        public long Amount { get; set; }
        public int Type { get; set; } //1 credit card
        public string CardEndNumber { get; set; } //4 ultimos números
    }
}
