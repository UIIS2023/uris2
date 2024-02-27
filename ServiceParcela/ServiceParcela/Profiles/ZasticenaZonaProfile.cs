using ServiceParcela.DtoModels;
using AutoMapper;

namespace ServiceParcela.Profiles
{
    /// <summary>
    /// ZasticenaZonaProfile
    /// </summary>
    /// 
    public class ZasticenaZonaProfile : Profile 
    {
        /// <summary>
        /// Mapiranje
        /// </summary>
        /// 
        public ZasticenaZonaProfile()
        {
            CreateMap<Entities.ZasticenaZona, ZasticenaZonaDto>();
            CreateMap<ZasticenaZonaDto, ZasticenaZonaDto>();
            CreateMap<ZasticenaZonaDto, Entities.ZasticenaZona>();
        }
    }
}
