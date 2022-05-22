using AutoMapper;
using Tringle.Core.DTOs;
using Tringle.Core.Entities;

namespace Tringle.Service.Mappers
{
    public class TransactionMapProfile : Profile
    {
        public TransactionMapProfile()
        {
            CreateMap<TransactionHistory, TransactionHistoryDto>();
        }
    }
}
