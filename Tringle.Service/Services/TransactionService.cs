using Tringle.Core.Entities;
using Tringle.Core.Repositories;
using Tringle.Core.Services;

namespace Tringle.Services.Service
{
    public class TransactionService : TringleService<TransactionHistory>, ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITringleRepository<TransactionHistory> repository, ITransactionRepository transactionRepository) : base(repository)
        {
            _transactionRepository = transactionRepository;
        }
    }
}
