using APINetBackMVC.Models.Dtos;
using APINetBackMVC.Models.Entities;
using AutoMapper;

namespace APINetBackMVC.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Bank, BankDto>();
            CreateMap<Fee, FeeDto>();
        }
    }
}
