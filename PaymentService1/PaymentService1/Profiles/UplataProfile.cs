using AutoMapper;
using PaymentService1.Entities;
using PaymentService1.Models;

namespace PaymentService1.Profiles
{
    public class UplataProfile : Profile
    {
        public UplataProfile() 
        {
            CreateMap<Uplata, UplataDto>();
            CreateMap<UplataCreationDto, Uplata>();
            CreateMap<Uplata, Uplata>();
        }
    }
}
