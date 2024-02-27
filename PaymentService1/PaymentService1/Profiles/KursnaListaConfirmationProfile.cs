using AutoMapper;
using PaymentService1.Entities;
using PaymentService1.Models;

namespace PaymentService1.Profiles
{
    public class KursnaListaConfirmationProfile : Profile
    {
        public KursnaListaConfirmationProfile()
        {
            CreateMap<KursnaListaConfirmation, KursnaListaConfirmationDto>();
            CreateMap<KursnaListaConfirmation, KursnaLista>();
        }
    }
}
