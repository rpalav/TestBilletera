using AutoMapper;
using BilleteraAPI.Application.Dtos;
using BilleteraAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
