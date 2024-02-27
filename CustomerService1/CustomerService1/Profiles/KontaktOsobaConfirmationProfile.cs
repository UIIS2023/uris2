using AutoMapper;
using CustomerService1.Entities;
using CustomerService1.Models;

namespace CustomerService1.Profiles
{
    public class KontaktOsobaConfirmationProfile : Profile
    {
        public KontaktOsobaConfirmationProfile()
        {
            CreateMap<KontaktOsobaConfirmation, KontaktOsobaConfirmationDto>();
            CreateMap<KontaktOsobaConfirmation, KontaktOsoba>();
        }
    }
}
