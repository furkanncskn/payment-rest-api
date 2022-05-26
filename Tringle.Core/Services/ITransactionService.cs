using Tringle.Core.DTOs;
using Tringle.Core.Entities;

namespace Tringle.Core.Services
{
    public interface ITransactionService : ITringleService<TransactionHistory>
    {
        Task<List<TransactionHistoryDto>> GetAllByIdAsync(int accountNumber);
    }
}
