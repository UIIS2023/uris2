using AutoMapper;
using CustomerService1.Entities;
using CustomerService1.Models;

namespace CustomerService1.Profiles
{
    public class PrioritetProfile : Profile
    {
        public PrioritetProfile()
        {
            CreateMap<Prioritet, PrioritetDto>();
            CreateMap<PrioritetCreationDto, Prioritet>();
            CreateMap<Prioritet, Prioritet>();
        }
    }
}
