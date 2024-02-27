using ServiceParcela.DtoModels;
using AutoMapper;

namespace ServiceParcela.Profiles
{
    /// <summary>
    /// DeoParceleProfile
    /// </summary>
    /// 
    public class DeoParceleProfile : Profile
    {
        /// <summary>
        /// Mapiranje
        /// </summary>
        /// 
        public DeoParceleProfile()
        {
            CreateMap<Entities.DeoParcele, DeoParceleDto>();
            CreateMap<DeoParceleDto, DeoParceleDto>();
            CreateMap<DeoParceleDto, Entities.DeoParcele>();
        }
    }
}
