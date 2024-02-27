using ServiceParcela.DtoModels;
using AutoMapper;

namespace ServiceParcela.Profiles
{
    /// <summary>
    /// KlasaProfile
    /// </summary>
    /// 
    public class KlasaProfile : Profile
    {
        /// <summary>
        /// Mapiranje
        /// </summary>
        /// 
        public KlasaProfile()
        {
            CreateMap<Entities.Klasa, KlasaDto>();
            CreateMap<KlasaDto, KlasaDto>();
            CreateMap<KlasaDto, Entities.Klasa>();
        }
    }
}
