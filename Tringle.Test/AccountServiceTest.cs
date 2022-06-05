using AutoMapper;
using Moq;
using System.Collections.Generic;
using Tringle.Core.DTOs;
using Tringle.Core.Entities;
using Tringle.Core.Enums;
using Tringle.Core.Repositories;
using Tringle.Service.Exceptions;
using Tringle.Services.Service;
using Xunit;

namespace Tringle.Test
{
    public class AccountServiceTest
    {
        private readonly List<Account> accounts;
        private readonly Mock<IMapper> mockMapper;
        private readonly Mock<IAccountRepository> mockAccountRepo;
        private readonly Mock<ITringleRepository<Account>> mockTringleRepo;
        private readonly AccountService accountService;

        public AccountServiceTest()
        {
            accounts = new List<Account>()
            {
                new Account()
                {
                    AccountNumber = 1,
                    AccountType = AccountTypes.individual,
                    CurrencyCode = CurrencyCodes.TRY,
                    OwnerName = "Furkan",
                    Balance = 1000
                }
            };
            mockAccountRepo = new Mock<IAccountRepository>();
            mockTringleRepo = new Mock<ITringleRepository<Account>>();
            mockMapper = new Mock<IMapper>();
            accountService = new AccountService(mockTringleRepo.Object, mockAccountRepo.Object, mockMapper.Object);
        }

        [Theory]
        [InlineData(1)]
        public async void GetAccountAsync_IsExist_ReturnAccountDto(int accountNumber)
        {
            var account = accounts.Find(account => account.AccountNumber == accountNumber);
            mockAccountRepo
                .Setup(x => x.GetByIdAsync(accountNumber))
                .ReturnsAsync(account);
            mockMapper
                .Setup(x => x.Map<AccountDto>(account))
                .Returns(new AccountDto()
                {
                    AccountNumber = account!.AccountNumber,
                    AccountType = account.AccountType,
                    CurrencyCode = account.CurrencyCode,
                    OwnerName = account.OwnerName,
                    Balance = account.Balance,
                });

            var result = await accountService.GetAccountAsync(accountNumber);

            Assert.IsType<AccountDto>(result);
            Assert.Equal(accountNumber, result.AccountNumber);
        }

        [Theory]
        [InlineData(2)]
        public async void GetAccountAsync_IsNotExist_ThrowNotFoundException(int accountNumber)
        {
            var service = new AccountService(mockTringleRepo.Object, mockAccountRepo.Object, mockMapper.Object);

            mockAccountRepo.Setup(x => x.GetByIdAsync(accountNumber)).Throws(new NotFoundException($"{accountNumber} not exist."));

            var result = await Assert.ThrowsAsync<NotFoundException>(() => service.GetAccountAsync(accountNumber));
            Assert.Equal("2 not exist.", result.Message);
        }
    }
}
