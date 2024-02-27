using System;
using AuctionService.DtoModels;
using AutoMapper;

namespace AuctionService.Profiles
{
	public class JavnoNadmetanjeProfile : Profile
	{
		public JavnoNadmetanjeProfile()
		{
			CreateMap<Entities.JavnoNadmetanje, JavnoNadmetanjeDto>();
            CreateMap<JavnoNadmetanjeDto, JavnoNadmetanjeDto>();
            CreateMap<JavnoNadmetanjeDto, Entities.JavnoNadmetanje>();
            CreateMap<JavnoNadmetanjeDto, JavnoNadmetanjeConformationDto>();
            CreateMap<Entities.JavnoNadmetanje, JavnoNadmetanjeConformationDto>();
            CreateMap<JavnoNadmetanjeConformationDto, JavnoNadmetanjeConformationDto>();
            CreateMap<JavnoNadmetanjeCreationDto, Entities.JavnoNadmetanje>();
            CreateMap<JavnoNadmetanjeUpdateDto, Entities.JavnoNadmetanje>();
            CreateMap<Entities.JavnoNadmetanje, Entities.JavnoNadmetanje>();
        }
	}
}

