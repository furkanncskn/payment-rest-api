using Microsoft.AspNetCore.Mvc;
using Tringle.Core.DTOs;
using Tringle.Core.DTOs.ResponseDtos;
using Tringle.Core.Services;

namespace Tringle.API.Controllers
{
    public class DepositController : BaseContoller
    {
        private readonly IPaymentService _paymentService;
        private readonly ITransactionService _transactionService;

        public DepositController(IPaymentService paymentService, ITransactionService transactionService)
        {
            _paymentService = paymentService;
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<IActionResult> Deposit(DepositOrWithdrawDto deposit)
        {
            await _paymentService.DepositAsync(deposit);
            return CreateResult(NoContentResponseDto.Success(201));
        }
    }
}
