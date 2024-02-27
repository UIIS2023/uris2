using AutoMapper;
using CustomerService1.Entities;
using CustomerService1.Models;

namespace CustomerService1.Profiles
{
    public class KupacProfile : Profile
    {
        public KupacProfile()
        {
            CreateMap<Kupac, KupacDto>();
            CreateMap<KupacCreationDto, Kupac>();
            CreateMap<Kupac, Kupac>();
        }
    }
}
