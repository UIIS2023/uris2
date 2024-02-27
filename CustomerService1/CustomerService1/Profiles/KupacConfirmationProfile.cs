using AutoMapper;
using CustomerService1.Entities;
using CustomerService1.Models;

namespace CustomerService1.Profiles
{
    public class KupacConfirmationProfile: Profile
    {
        public KupacConfirmationProfile() 
        {
            CreateMap<KupacConfirmation, KupacConfirmationDto>();
            CreateMap<KupacConfirmation, Kupac>();
        }
    }
}
