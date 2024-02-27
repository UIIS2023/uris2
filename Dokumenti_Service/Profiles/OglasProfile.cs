using Dokumenti_Service.Entities.Oglas;
using Dokumenti_Service.Models;
using AutoMapper;
using Dokumenti_Service.Entities.Zalba;

namespace Dokumenti_Service.Profiles
{
    public class OglasProfile: Profile
    {
        public OglasProfile()
        {
            CreateMap<OglasDTO, Oglas>();
            CreateMap<OglasCreationDTO, Oglas>();
            CreateMap<Oglas, Oglas>();
            CreateMap<Oglas, OglasDTO>();

        }
    }
}
