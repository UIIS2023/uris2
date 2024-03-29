﻿using System;
using AutoMapper;
using KorisnikService.DtoModels;
using KorisnikService.Entities;

namespace KorisnikService.Profiles
{
	public class KorisnikProfile : Profile
	{
		public KorisnikProfile()
		{
			CreateMap<Korisnik, KorisnikDto>();
			CreateMap<KorisnikDto, Korisnik>();
			CreateMap<KorisnikUpdateDto, Korisnik>();
            CreateMap<KorisnikCreateDto, Korisnik>();
            CreateMap<KorisnikUpdateDto, KorisnikDto>();
			CreateMap<Korisnik, Korisnik>();

        }
	}
}

