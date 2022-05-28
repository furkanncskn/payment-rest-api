using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tringle.Core.DTOs;
using Tringle.Core.DTOs.ResponseDtos;
using Tringle.Core.Services;

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
        public async Task<IActionResult> GetAccount(int accountNumber)
        {
            var accountDto = await _accountService.GetAccountAsync(accountNumber);
            return CreateResult(ContentResponseDto<AccountDto>.Success(200, accountDto));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(PostAccountDto postAccountDto)
        {
            await _accountService.CreateAccountAsync(postAccountDto);
            return CreateResult(ContentResponseDto<PostAccountDto>.Success(201, postAccountDto));
        }

        [HttpDelete("{accountNumber}")]
        public async Task<IActionResult> DeleteAccount(int accountNumber)
        {
            await _accountService.DeleteAccountAsync(accountNumber);
            return CreateResult(NoContentResponseDto.Success(204));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAccount(AccountDto accountDto)
        {
            await _accountService.UpdateAccountAsync(accountDto);
            return CreateResult(NoContentResponseDto.Success(201));
        }
    }
}
