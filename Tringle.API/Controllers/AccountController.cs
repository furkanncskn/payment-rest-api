using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tringle.Core.DTOs;
using Tringle.Core.DTOs.ResponseDtos;
using Tringle.Core.Entities;
using Tringle.Core.Services;
using Tringle.Service.Exceptions;

namespace Tringle.API.Controllers
{
    public class AccountController : BaseContoller
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(IAccountService service, IMapper mapper)
        {
            _accountService = service;
            _mapper = mapper;
        }

        [HttpGet("{accountNumber}")]
        public async Task<IActionResult> Get(int accountNumber)
        {
            var account = await _accountService.GetByIdAsync(accountNumber) ?? throw new NotFoundException($"{accountNumber} not exist.");
            var accoutDto = _mapper.Map<AccountDto>(account);
            return CreateResult(ContentResponseDto<AccountDto>.Success(200, accoutDto));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AccountDto accountDto)
        {
            var account = _mapper.Map<Account>(accountDto);
            if (await _accountService.ExistAsync(account)) throw new ClientSideException($"Account number {accountDto.AccountNumber} exists.");
            await _accountService.AddAsync(account);
            return CreateResult(ContentResponseDto<AccountDto>.Success(201, accountDto));
        }

        [HttpDelete("{accountNumber}")]
        public async Task<IActionResult> Delete(int accountNumber)
        {
            await _accountService.DeleteByIdAsync(accountNumber);
            return CreateResult(NoContentResponseDto.Success(204));
        }
    }
}
