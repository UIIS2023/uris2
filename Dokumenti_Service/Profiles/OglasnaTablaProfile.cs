using Dokumenti_Service.Entities.Oglas;
using Dokumenti_Service.Entities.Zalba;
using Dokumenti_Service.Models;
using AutoMapper;

namespace Dokumenti_Service.Profiles
{
    public class OglasnaTablaProfile : Profile
    {

        /// <summary>
        /// Konstruktor za mapiranje oglasne table
        /// </summary>
        public OglasnaTablaProfile()
        {
            CreateMap<OglasnaTabla, OglasnaTablaDTO>();
            CreateMap<OglasnaTablaDTO, OglasnaTabla>();
            CreateMap<OglasnaTabla, OglasnaTabla>();
            CreateMap<OglasnaTablaCreationDTO, OglasnaTabla>();

        }
    }
}
