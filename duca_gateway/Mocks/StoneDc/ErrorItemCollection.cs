using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace duca_gateway.Mocks.StoneDc
{
    public class ErrorItemCollection
    {
        public string Description { get; set; }
        public long ErrorCode { get; set; }
        public string ErrorField { get; set; }
        public string SeverityCode { get; set; }
    }
}
