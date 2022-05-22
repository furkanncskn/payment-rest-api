using System.ComponentModel.DataAnnotations;
using Tringle.Core.Enums;

namespace Tringle.Core.Entities
{
    public class Account
    {
        [Key]
        public int AccountNumber { get; set; }
        public string? OwnerName { get; set; }
        public AccountTypes AccountType { get; set; }
        public CurrencyCodes CurrencyCode { get; set; }
        public decimal Balance { get; set; }
    }
}
