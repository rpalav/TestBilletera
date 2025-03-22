using AutoMapper;
using BilleteraAPI.Application.Dtos;
using BilleteraAPI.Domain.Entities;

namespace BilleteraAPI.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BilleteraDto, BilleteraEntity>().ReverseMap();
        }
    }
}
