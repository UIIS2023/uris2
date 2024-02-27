using UgovorZakupService.DtoModels;
using AutoMapper;


namespace UgovorZakupService.Profiles
{
    public class UgovorOZakupuProfile : Profile
    {
           public UgovorOZakupuProfile() 
           {
            CreateMap<Entities.UgovorOZakupu, UgovorOZakupuDto>();
            CreateMap<UgovorOZakupuDto, JavnoNadmetanjeDto>();
            CreateMap<UgovorOZakupuDto, Entities.UgovorOZakupu>();
            CreateMap<UgovorOZakupuDto, UgovorOZakupuConfirmationDto>();
            CreateMap<Entities.UgovorOZakupu, UgovorOZakupuConfirmationDto>();
            CreateMap<UgovorOZakupuConfirmationDto, UgovorOZakupuConfirmationDto>();
            CreateMap<UgovorOZakupuCreationDto, Entities.UgovorOZakupu>();
            CreateMap<UgovorOZakupuUpdateDto, Entities.UgovorOZakupu>();
        }
    }
}
