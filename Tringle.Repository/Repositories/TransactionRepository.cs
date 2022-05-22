using Tringle.Core.Entities;
using Tringle.Core.Repositories;

namespace Tringle.Repository.Repositories
{
    public class TransactionRepository : TringleRepository<TransactionHistory>, ITransactionRepository
    {
        public TransactionRepository(DataContext<TransactionHistory> context) : base(context)
        {
        }
    }
}
