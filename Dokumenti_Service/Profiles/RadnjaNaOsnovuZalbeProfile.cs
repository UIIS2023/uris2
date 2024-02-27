
using Dokumenti_Service.Entities.Oglas;
using Dokumenti_Service.Entities.Zalba;
using Dokumenti_Service.Models;
using AutoMapper;

namespace Dokumenti_Service.Profiles
{
    public class RadnjaNaOsnovuZalbeProfile : Profile
    {
        public RadnjaNaOsnovuZalbeProfile()
        {
            CreateMap<RadnjaNaOsnovuZalbeCreationDTO, RadnjaNaOsnovuZalbe>();
            CreateMap<RadnjaNaOsnovuZalbe, RadnjaNaOsnovuZalbeDTO>();
            CreateMap<RadnjaNaOsnovuZalbe, RadnjaNaOsnovuZalbe>();
            CreateMap<RadnjaNaOsnovuZalbeDTO, RadnjaNaOsnovuZalbe>();

        }
    }
}
