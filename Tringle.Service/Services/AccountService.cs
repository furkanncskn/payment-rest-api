using Tringle.Core.Entities;
using Tringle.Core.Repositories;
using Tringle.Core.Services;

namespace Tringle.Services.Service
{
    public class AccountService : TringleService<Account>, IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(ITringleRepository<Account> repository, IAccountRepository accountRepository) : base(repository)
        {
            _accountRepository = accountRepository;
        }
    }
}
