using System;
using AuctionService.DtoModels;
using AutoMapper;

namespace AuctionService.Profiles
{
	public class TipNadmetanjaProfile : Profile
	{
		public TipNadmetanjaProfile()
		{
			CreateMap<Entities.TipJavnogNadmetanja, TipNadmetanjaDto>();
            CreateMap<TipNadmetanjaDto, TipNadmetanjaDto>();
			CreateMap<TipNadmetanjaDto, Entities.TipJavnogNadmetanja>();
			CreateMap<TipNadmetanjaDto, TipJavnogNadmetanjaConformationDto>();
            CreateMap<Entities.TipJavnogNadmetanja, TipJavnogNadmetanjaConformationDto>();
            CreateMap<TipJavnogNadmetanjaConformationDto, TipJavnogNadmetanjaConformationDto>();
            CreateMap<TipNadmetanjaCreationDto, Entities.TipJavnogNadmetanja>();
            CreateMap<TipJavnogNadmetanjaUpdateDto, Entities.TipJavnogNadmetanja>();

        }
	}
}

