using Tringle.Core.DTOs;
using Tringle.Core.Entities;
using Tringle.Core.Enums;
using Tringle.Core.Repositories;
using Tringle.Core.Services;
using Tringle.Service.Exceptions;

namespace Tringle.Services.Service
{
    public class PaymentService : TringleService<Account>, IPaymentService
    {
        private readonly IAccountRepository _accountRepository;

        public PaymentService(ITringleRepository<Account> repository, IAccountRepository accountRepository) : base(repository)
        {
            _accountRepository = accountRepository;
        }

        public async Task PaymentAsync(PaymentDto paymentDto)
        {
            if (paymentDto.SenderAccount == paymentDto.ReceiverAccount)
            {
                throw new ClientSideException("Receiver and sender accounts must be different");
            }

            var account = (await _accountRepository
                .WhereAsync(p =>
                (
                    p.AccountNumber == paymentDto.SenderAccount ||
                    p.AccountNumber == paymentDto.ReceiverAccount
                ))).ToList();

            if (account.Count != 2) throw new NotFoundException("Not found user account.");

            account.ForEach(p =>
            {
                if (p.AccountNumber == paymentDto.SenderAccount)
                {
                    if (p.AccountType != AccountTypes.individual)
                    {
                        throw new ClientSideException("Sender account type must be individual.");
                    }

                    if (p.Balance < paymentDto.Amount)
                    {
                        throw new ClientSideException("There is not enough money in the account for the payment transaction.");
                    }

                    p.Balance -= paymentDto.Amount;
                }
                else if (p.AccountNumber == paymentDto.ReceiverAccount)
                {
                    if (p.AccountType != AccountTypes.corporate)
                    {
                        throw new ClientSideException("Receiver account type must be corporate.");
                    }

                    p.Balance += paymentDto.Amount;
                }
            });
            await _accountRepository.UpdateRangeAsync(account);
        }

        public async Task DepositAsync(DepositOrWithdrawDto depositOrWithdrawDto)
        {
            var account = (await _accountRepository
                .WhereAsync(x => x.AccountNumber == depositOrWithdrawDto.AccountNumber))
                .SingleOrDefault() ?? throw new NotFoundException("Not found user account.");

            if (account.AccountType != AccountTypes.individual)
            {
                throw new ClientSideException("Account type must be individual.");
            }

            account.Balance += depositOrWithdrawDto.Amount;
            await _accountRepository.UpdateAsync(account);
        }

        public async Task WithdrawAsync(DepositOrWithdrawDto depositOrWithdrawDto)
        {
            var account = (await _accountRepository
                .WhereAsync(x => x.AccountNumber == depositOrWithdrawDto.AccountNumber))
                .SingleOrDefault() ?? throw new NotFoundException("Not found user account.");

            if (account.AccountType != AccountTypes.individual)
            {
                throw new ClientSideException("Account type must be individual.");
            }
            if (account.Balance < depositOrWithdrawDto.Amount)
            {
                throw new ClientSideException("There is not enough money in the account for the withdrawal transaction.");
            }

            account.Balance -= depositOrWithdrawDto.Amount;
            await _accountRepository.UpdateAsync(account);
        }
    }
}
