using AutoMapper;
using Dokumenti_Service.Entities.Zalba;
using Dokumenti_Service.Models;

namespace Dokumenti_Service.Profiles
{
    public class TipZalbeProfile : Profile
    {
        /// <summary>
        /// Konstruktor za mapiranje tipa žalbe
        /// </summary>
        public TipZalbeProfile()
        {
            CreateMap<TipZalbe, TipZalbeDTO>();
            CreateMap<TipZalbeCreationDTO,  TipZalbe>();
            CreateMap<TipZalbe, TipZalbe>();
            CreateMap<TipZalbeDTO, TipZalbe>();

        }
    }
}
