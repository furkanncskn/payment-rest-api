using Microsoft.AspNetCore.Mvc;
using Tringle.Core.DTOs;
using Tringle.Core.DTOs.ResponseDtos;
using Tringle.Core.Entities;
using Tringle.Core.Services;

namespace Tringle.API.Controllers
{
    public class WithdrawController : BaseContoller
    {
        private readonly IPaymentService _paymentService;
        private readonly ITransactionService _transactionService;

        public WithdrawController(IPaymentService service, ITransactionService transactionService)
        {
            _paymentService = service;
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<IActionResult> Withdraw(DepositOrWithdrawDto withdraw)
        {
            await _paymentService.WithdrawAsync(withdraw);
            await _transactionService.AddAsync(new TransactionHistory()
            {
                AccountNumber = withdraw.AccountNumber,
                Amount = withdraw.Amount,
                CreatedAt = DateTime.Now,
                TransactionType = Core.Enums.TransactionTypes.withdraw
            });
            return CreateResult(NoContentResponseDto.Success(201));
        }
    }
}
