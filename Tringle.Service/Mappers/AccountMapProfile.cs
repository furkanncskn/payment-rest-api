using AutoMapper;
using Tringle.Core.DTOs;
using Tringle.Core.Entities;

namespace Tringle.Service.Mappers
{
    public class AccountMapProfile : Profile
    {
        public AccountMapProfile()
        {
            CreateMap<AccountDto, Account>().ReverseMap();
            CreateMap<PostAccountDto, Account>();
        }
    }
}
