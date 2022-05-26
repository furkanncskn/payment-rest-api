using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tringle.Core.DTOs;
using Tringle.Core.DTOs.ResponseDtos;
using Tringle.Core.Services;

namespace Tringle.API.Controllers
{
    public class AccountingController : BaseContoller
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public AccountingController(ITransactionService service, IMapper mapper)
        {
            _transactionService = service;
            _mapper = mapper;
        }

        [HttpGet("{accountNumber}")]
        public async Task<IActionResult> GetAllById(int accountNumber)
        {
            var transactionHistroyDto = await _transactionService.GetAllByIdAsync(accountNumber);
            return CreateResult(ContentResponseDto<List<TransactionHistoryDto>>.Success(200, transactionHistroyDto));
        }
    }
}
