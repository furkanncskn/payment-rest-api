using Tringle.Core.Entities;
using Tringle.Core.Repositories;
using Tringle.Core.Services;
using Tringle.Service.Exceptions;

namespace Tringle.Services.Service
{
    public class AccountService : TringleService<Account>, IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(ITringleRepository<Account> repository, IAccountRepository accountRepository) : base(repository)
        {
            _accountRepository = accountRepository;
        }

        public Task<bool> ExistAsync(Account account)
        {
            return _accountRepository.AnyAsync(p => p.AccountNumber == account.AccountNumber);
        }

        public Task DeleteByIdAsync(int id)
        {
            var account = _accountRepository.WhereAsync(p => p.AccountNumber == id).Result.SingleOrDefault() ?? throw new ClientSideException($"{id} not exist.");
            return _accountRepository.DeleteAsync(account);
        }
    }
}
