using ServiceParcela.DtoModels;
using AutoMapper;

namespace ServiceParcela.Profiles
{
    /// <summary>
    /// ParcelaProfile
    /// </summary>
    /// 
    public class ParcelaProfile : Profile
    {
        /// <summary>
        /// Mapiranje
        /// </summary>
        /// 
        public ParcelaProfile()
        {
            CreateMap<Entities.Parcela, ParcelaDto>();
            CreateMap<ParcelaDto, ParcelaDto>();
            CreateMap<ParcelaDto, Entities.Parcela>();
        }
    }
}
