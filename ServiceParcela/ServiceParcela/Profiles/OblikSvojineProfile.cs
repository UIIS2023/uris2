using ServiceParcela.DtoModels;
using AutoMapper;

namespace ServiceParcela.Profiles
{
    /// <summary>
    /// OblikSvojineProfile
    /// </summary>
    /// 
    public class OblikSvojineProfile : Profile 
    {
        /// <summary>
        /// Mapiranje
        /// </summary>
        /// 
        public OblikSvojineProfile()
        {
            CreateMap<Entities.OblikSvojine, OblikSvojineDto>();
            CreateMap<OblikSvojineDto, OblikSvojineDto>();
            CreateMap<OblikSvojineDto, Entities.OblikSvojine>();
        }
    }
}
