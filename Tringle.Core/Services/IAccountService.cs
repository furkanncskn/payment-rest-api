using Tringle.Core.DTOs;
using Tringle.Core.Entities;

namespace Tringle.Core.Services
{
    public interface IAccountService : ITringleService<Account>
    {
        Task<AccountDto> GetAccountAsync(int accountNumber);
        Task CreateAccountAsync(PostAccountDto postAccountDto);
    }
}
