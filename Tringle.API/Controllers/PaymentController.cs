using Microsoft.AspNetCore.Mvc;
using Tringle.Core.DTOs;
using Tringle.Core.DTOs.ResponseDtos;
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
            return CreateResult(NoContentResponseDto.Success(201));
        }
    }
}
