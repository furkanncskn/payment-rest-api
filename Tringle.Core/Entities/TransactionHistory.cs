using Tringle.Core.Enums;

namespace Tringle.Core.Entities
{
    public class TransactionHistory
    {
        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public TransactionTypes TransactionType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
