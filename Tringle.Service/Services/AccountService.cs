using AutoMapper;
using Tringle.Core.DTOs;
using Tringle.Core.Entities;
using Tringle.Core.Enums;
using Tringle.Core.Repositories;
using Tringle.Core.Services;
using Tringle.Service.Exceptions;

namespace Tringle.Services.Service
{
    public class AccountService : TringleService<Account>, IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountService(ITringleRepository<Account> repository, IAccountRepository accountRepository, IMapper mapper) : base(repository)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<AccountDto> GetAccountAsync(int accountNumber)
        {
            var account = await _accountRepository.GetByIdAsync(accountNumber) ?? throw new NotFoundException($"{accountNumber} not exist.");
            return _mapper.Map<AccountDto>(account);
        }

        public async Task CreateAccountAsync(PostAccountDto postAccountDto)
        {
            if (!Enum.IsDefined(typeof(CurrencyCodes), postAccountDto.CurrencyCode!)) throw new ClientSideException("Currency code is invalid.");
            if (!Enum.IsDefined(typeof(AccountTypes), postAccountDto.AccountType!)) throw new ClientSideException("Account type is invalid.");
            var account = _mapper.Map<Account>(postAccountDto);
            if (await _accountRepository.ExistAsync(account)) throw new ClientSideException($"Account number {postAccountDto.AccountNumber} exists.");
            await _accountRepository.AddAsync(account);
        }

        public async Task DeleteAccountAsync(int accountNumber)
        {
            var account = _accountRepository.WhereAsync(account => account.AccountNumber == accountNumber).Result.SingleOrDefault();
            if (account == null) throw new NotFoundException($"{accountNumber} not exist");
            await _accountRepository.DeleteAsync(account);
        }

        public async Task UpdateAccountAsync(AccountDto accountDto)
        {
            var account = _mapper.Map<Account>(accountDto);
            await _accountRepository.UpdateAsync(account);
        }
    }
}