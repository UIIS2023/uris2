using ServiceParcela.DtoModels;
using AutoMapper;

namespace ServiceParcela.Profiles
{
    /// <summary>
    /// KatastarskaOpstinaProfile
    /// </summary>
    /// 
    public class KatastarskaOpstinaProfile : Profile
    {
        /// <summary>
        /// Mapiranje
        /// </summary>
        /// 
        public KatastarskaOpstinaProfile()
        {
            CreateMap<Entities.KatastarskaOpstina, KatastarskaOpstinaDto>();
            CreateMap<KatastarskaOpstinaDto, KatastarskaOpstinaDto>();
            CreateMap<KatastarskaOpstinaDto, Entities.KatastarskaOpstina>();
        }
    }
}
