using AutoMapper;
using Tringle.Core.DTOs;
using Tringle.Core.Entities;
using Tringle.Core.Repositories;
using Tringle.Core.Services;
using Tringle.Service.Exceptions;

namespace Tringle.Services.Service
{
    public class TransactionService : TringleService<TransactionHistory>, ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITringleRepository<TransactionHistory> repository, ITransactionRepository transactionRepository, IMapper mapper) : base(repository)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<List<TransactionHistoryDto>> GetAllByIdAsync(int accountNumber)
        {
            var transactionHistory = (await _transactionRepository.WhereAsync(p => p.AccountNumber == accountNumber)).ToList();
            if (transactionHistory == null || transactionHistory.Count == 0) throw new NotFoundException("Account history not found");
            return _mapper.Map<List<TransactionHistoryDto>>(transactionHistory);
        }
    }
}
