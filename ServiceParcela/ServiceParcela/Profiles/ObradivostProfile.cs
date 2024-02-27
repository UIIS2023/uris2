using ServiceParcela.DtoModels;
using AutoMapper;

namespace ServiceParcela.Profiles
{
    /// <summary>
    /// ObradivostProfile
    /// </summary>
    /// 
    public class ObradivostProfile : Profile    
    {
        /// <summary>
        /// Mapiranje
        /// </summary>
        /// 
        public ObradivostProfile()
        {
            CreateMap<Entities.Obradivost, ObradivostDto>();
            CreateMap<ObradivostDto, ObradivostDto>();
            CreateMap<ObradivostDto, Entities.Obradivost>();
        }
    }
}
