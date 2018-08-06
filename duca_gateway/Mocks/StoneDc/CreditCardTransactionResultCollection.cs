using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace duca_gateway.Mocks.StoneDc
{
    public class CreditCardTransactionResultCollection
    {
        public string AcquirerMessage { get; set; }
        public string AcquirerName { get; set; }
        public string AcquirerReturnCode { get; set; }
        public string AffiliationCode { get; set; }
        public long AmountInCents { get; set; }
        public string AuthorizationCode { get; set; }
        public long AuthorizedAmountInCents { get; set; }
        public long CapturedAmountInCents { get; set; }
        public string CapturedDate { get; set; }
        public CreditCard CreditCard { get; set; }
        public string CreditCardOperation { get; set; }
        public string CreditCardTransactionStatus { get; set; }
        public string DueDate { get; set; }
        public long ExternalTime { get; set; }
        public string PaymentMethodName { get; set; }
        public string RefundedAmountInCents { get; set; }
        public bool Success { get; set; }
        public string TransactionIdentifier { get; set; }
        public string TransactionKey { get; set; }
        public string TransactionKeyToAcquirer { get; set; }
        public string TransactionReference { get; set; }
        public string UniqueSequentialNumber { get; set; }
        public string VoidedAmountInCents { get; set; }



    }
}