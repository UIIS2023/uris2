using AutoMapper;
using Dokumenti_Service.Entities.Dokument;
using Dokumenti_Service.Entities.Zalba;
using Dokumenti_Service.Models;

namespace Dokumenti_Service.Profiles
    
{
    public class StatusProfile: Profile
    {
        public StatusProfile()
        {
            CreateMap<Status, StatusDTO>();
            CreateMap<StatusCreationDTO, Status>();
            CreateMap<Status, Status>();
            CreateMap<StatusDTO, Status>();

        }
    }
}
