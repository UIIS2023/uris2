using System;
using AuctionService.DtoModels;
using AutoMapper;

namespace AuctionService.Profiles
{
	public class StatusNadmetanjaProdfile : Profile
	{
		public StatusNadmetanjaProdfile()
		{
			CreateMap<Entities.StatusNadmetanja, StatusNadmetanjaConformationDto>();
            CreateMap<Entities.StatusNadmetanja, StatusNadmetanjaDto>();
            CreateMap<StatusNadmetanjaDto, StatusNadmetanjaDto>();
            CreateMap<StatusNadmetanjaConformationDto, Entities.StatusNadmetanja>();
            CreateMap<StatusNadmetanjaCreationDto, Entities.StatusNadmetanja>();
            CreateMap<StatusJavnogNadmetanjaUpdateDto, Entities.StatusNadmetanja>();
            CreateMap<StatusNadmetanjaDto, StatusNadmetanjaConformationDto>();
            CreateMap<StatusNadmetanjaDto, Entities.StatusNadmetanja>();
            CreateMap<Entities.StatusNadmetanja, Entities.StatusNadmetanja>();

        }
	}
}

