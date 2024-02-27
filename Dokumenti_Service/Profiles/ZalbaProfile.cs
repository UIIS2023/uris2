using AutoMapper;
using Dokumenti_Service.Entities.Zalba;
using Dokumenti_Service.Models;

namespace Dokumenti_Service.Profiles
{
    public class ZalbaProfile : Profile
    {
        public ZalbaProfile()
        {
            CreateMap<Zalba, ZalbaDTO>();
            CreateMap<ZalbaCreationDTO, Zalba>();
            CreateMap<Zalba, Zalba>();
            CreateMap<ZalbaDTO, Zalba>();

        }
    }
}
