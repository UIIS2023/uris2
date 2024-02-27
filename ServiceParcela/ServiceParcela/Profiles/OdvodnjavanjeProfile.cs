using ServiceParcela.DtoModels;
using AutoMapper;

namespace ServiceParcela.Profiles
{
    /// <summary>
    /// OdvodnjavanjeProfile
    /// </summary>
    /// 
    public class OdvodnjavanjeProfile : Profile 
    {
        /// <summary>
        /// Mapiranje
        /// </summary>
        /// 
        public OdvodnjavanjeProfile()
        {
            CreateMap<Entities.Odvodnjavanje, OdvodnjavanjeDto>();
            CreateMap<OdvodnjavanjeDto, OdvodnjavanjeDto>();
            CreateMap<OdvodnjavanjeDto, Entities.Odvodnjavanje>();
        }
    }
}
