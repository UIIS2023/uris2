using ServiceParcela.DtoModels;
using AutoMapper;

namespace ServiceParcela.Profiles
{
    /// <summary>
    /// KulturaProfile
    /// </summary>
    /// 
    public class KulturaProfile : Profile
    {
        /// <summary>
        /// Mapiranje
        /// </summary>
        /// 
        public KulturaProfile()
        {
            CreateMap<Entities.Kultura, KulturaDto>();
            CreateMap<KulturaDto, KulturaDto>();
            CreateMap<KulturaDto, Entities.Kultura>();
        }
    }
}
