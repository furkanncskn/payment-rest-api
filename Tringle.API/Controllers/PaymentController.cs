using Microsoft.AspNetCore.Mvc;
using Tringle.Core.DTOs;
using Tringle.Core.DTOs.ResponseDtos;
using Tringle.Core.Entities;
using Tringle.Core.Services;

namespace Tringle.API.Controllers
{
    public class PaymentController : BaseContoller
    {
        private readonly IPaymentService _paymentService;
        private readonly ITransactionService _transactionService;

        public PaymentController(IPaymentService paymentService, ITransactionService transactionService)
        {
            _paymentService = paymentService;
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<IActionResult> Payment(PaymentDto paymentDto)
        {
            await _paymentService.PaymentAsync(paymentDto);
            await _transactionService.AddAsync(new TransactionHistory()
            {
                AccountNumber = paymentDto.SenderAccount,
                Amount = paymentDto.Amount,
                CreatedAt = DateTime.UtcNow,
                TransactionType = Core.Enums.TransactionTypes.payment
            });
            return CreateResult(NoContentResponseDto.Success(201));
        }
    }
}
