using AutoMapper;
using UgovorZakupService.DtoModels;

namespace UgovorZakupService.Profiles
{
    public class TipGarancijeProfile : Profile
    {
        public TipGarancijeProfile() 
        {
            CreateMap<Entities.TipGarancije, TipGarancijeDto>();
            CreateMap<TipGarancijeDto, JavnoNadmetanjeDto>();
            CreateMap<TipGarancijeDto, Entities.TipGarancije>();
            CreateMap<TipGarancijeDto, TipGarancijeConfirmationDto>();
            CreateMap<Entities.TipGarancije, TipGarancijeConfirmationDto>();
            CreateMap<TipGarancijeConfirmationDto, TipGarancijeConfirmationDto>();
            CreateMap<TipGarancijeCreationDto, Entities.TipGarancije>();
            CreateMap<TipGarancijeUpdateDto, Entities.TipGarancije>();
        }
    }
}
