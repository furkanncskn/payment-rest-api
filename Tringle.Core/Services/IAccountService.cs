using Tringle.Core.Entities;

namespace Tringle.Core.Services
{
    public interface IAccountService : ITringleService<Account>
    {
        Task<bool> ExistAsync(Account account);
        Task DeleteByIdAsync(int id);
    }
}
