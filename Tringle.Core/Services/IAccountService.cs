using Tringle.Core.DTOs;
using Tringle.Core.Entities;

namespace Tringle.Core.Services
{
    public interface IAccountService : ITringleService<Account>
    {
        Task Create(PostAccountDto postAccountDto);
    }
}
