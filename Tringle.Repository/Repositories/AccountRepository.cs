using Tringle.Core.Entities;
using Tringle.Core.Repositories;

namespace Tringle.Repository.Repositories
{
    public class AccountRepository : TringleRepository<Account>, IAccountRepository
    {
        public AccountRepository(DataContext<Account> context) : base(context)
        {
        }
    }
}
