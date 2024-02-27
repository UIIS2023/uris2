using AutoMapper;
using PaymentService1.Entities;
using PaymentService1.Models;

namespace PaymentService1.Profiles
{
    public class KursnaListaProfile : Profile
    {
        public KursnaListaProfile()
        {
            CreateMap<KursnaLista, KursnaListaDto>();
            CreateMap<KursnaListaCreationDto, KursnaLista>();
            CreateMap<KursnaLista, KursnaLista>();
        }
    }
}
