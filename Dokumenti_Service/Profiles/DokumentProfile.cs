using AutoMapper;
using Dokumenti_Service.Entities.Dokument;
using Dokumenti_Service.Entities.Zalba;
using Dokumenti_Service.Models;
using AutoMapper;

namespace Dokumenti_Service.Profiles
{
    public class DokumentProfile : Profile
    {

        /// <summary>
        /// Konstruktor za mapiranje dokument
        /// </summary>
        public DokumentProfile() 
        {
            CreateMap<Dokument, DokumentDTO>();
            CreateMap<DokumentCreationDTO, Dokument>();
            CreateMap<Dokument, Dokument>();
            CreateMap<DokumentDTO, Dokument>();

        }
    }
}
