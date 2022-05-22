using Tringle.Core.DTOs;
using Tringle.Core.Entities;

namespace Tringle.Core.Services
{
    public interface IPaymentService : ITringleService<Account>
    {
        Task PaymentAsync(PaymentDto paymentDto);
        Task DepositAsync(DepositOrWithdrawDto depositOrWithdrawDto);
        Task WithdrawAsync(DepositOrWithdrawDto depositOrWithdrawDto);
    }
}
