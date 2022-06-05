using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Tringle.API.Controllers;
using Tringle.Core.DTOs;
using Tringle.Core.DTOs.ResponseDtos;
using Tringle.Core.Services;
using Xunit;

namespace Tringle.Test
{
    public class AccountControllerTest
    {
        private readonly List<AccountDto> accountDtos;
        private readonly Mock<IAccountService> mockAccountService;
        private readonly AccountController accountController;

        public AccountControllerTest()
        {
            accountDtos = new List<AccountDto>();
            mockAccountService = new Mock<IAccountService>();
            accountController = new AccountController(mockAccountService.Object);
        }

        [Theory]
        [InlineData(1)]
        public async void GetAccount_IsExist_ReturnContentResponseDtoAndResultOk(int accountNumber)
        {
            mockAccountService
                .Setup(x => x.GetAccountAsync(accountNumber))!
                .ReturnsAsync(accountDtos.Find(x => x.AccountNumber == accountNumber));

            var result = (ObjectResult)await accountController.GetAccount(accountNumber);

            Assert.Equal(200, result.StatusCode);
            Assert.IsAssignableFrom<ContentResponseDto<AccountDto>>(result.Value);
        }
    }
}