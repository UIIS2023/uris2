using AutoMapper;
using PaymentService1.Entities;
using PaymentService1.Models;

namespace PaymentService1.Profiles
{
    public class UplataConfirmationProfile : Profile
    {
        public UplataConfirmationProfile()
        {
            CreateMap<UplataConfirmation, UplataConfirmationDto>();
            CreateMap<UplataConfirmation, Uplata>();
        }
    }
}
