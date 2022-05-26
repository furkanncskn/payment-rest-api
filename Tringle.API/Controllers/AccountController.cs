using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tringle.Core.DTOs;
using Tringle.Core.DTOs.ResponseDtos;
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
        public async Task<IActionResult> Create(PostAccountDto postAccountDto)
        {
            await _accountService.Create(postAccountDto);
            return CreateResult(ContentResponseDto<PostAccountDto>.Success(201, postAccountDto));
        }
    }
}
