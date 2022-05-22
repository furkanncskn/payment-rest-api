using Microsoft.AspNetCore.Mvc;
using Tringle.Core.DTOs.ResponseDtos;
using Tringle.Core.Entities;
using Tringle.Core.Services;
using Tringle.Service.Exceptions;

namespace Tringle.API.Controllers
{
    public class AccountingController : BaseContoller
    {
        private readonly ITransactionService _transactionService;

        public AccountingController(ITransactionService service)
        {
            _transactionService = service;
        }

        [HttpGet("{accountNumber}")]
        public async Task<IActionResult> GetAllById(int accountNumber)
        {
            var data = (await _transactionService.WhereAsync(p => p.AccountNumber == accountNumber)).ToList();
            if (data == null || data.Count == 0) throw new NotFoundException("Account history not found");
            return CreateResult(ContentResponseDto<List<TransactionHistory>>.Success(200, data));
        }
    }
}
