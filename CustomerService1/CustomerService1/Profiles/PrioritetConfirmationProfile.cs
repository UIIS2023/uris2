using AutoMapper;
using CustomerService1.Entities;
using CustomerService1.Models;

namespace CustomerService1.Profiles
{
    public class PrioritetConfirmationProfile : Profile
    {
        public PrioritetConfirmationProfile()
        {
            CreateMap<PrioritetConfirmation, PrioritetConfirmationDto>();
            CreateMap<PrioritetConfirmation, Prioritet>();
        }
    }
}
