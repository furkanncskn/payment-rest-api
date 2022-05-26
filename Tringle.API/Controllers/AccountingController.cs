using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tringle.Core.DTOs;
using Tringle.Core.DTOs.ResponseDtos;
using Tringle.Core.Services;
using Tringle.Service.Exceptions;

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
            var transactionHistory = (await _transactionService.WhereAsync(p => p.AccountNumber == accountNumber)).ToList();
            if (transactionHistory == null || transactionHistory.Count == 0) throw new NotFoundException("Account history not found");
            var transationHistoryDto = _mapper.Map<List<TransactionHistoryDto>>(transactionHistory);
            return CreateResult(ContentResponseDto<List<TransactionHistoryDto>>.Success(200, transationHistoryDto));
        }
    }
}
