using AutoMapper;
using CustomerService1.Entities;
using CustomerService1.Models;

namespace CustomerService1.Profiles
{
    public class KontaktOsobaProfile : Profile
    {
        public KontaktOsobaProfile()
        {
            CreateMap<KontaktOsoba, KontaktOsobaDto>();
            CreateMap<KontaktOsobaCreationDto, KontaktOsoba>();
            CreateMap<KontaktOsoba, KontaktOsoba>();
        }
    }
}
