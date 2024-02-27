using AutoMapper;
using AdresaService.Entities;
using AdresaService.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaService.Profiles
{
    public class AdresaProfile : Profile
    {
        public AdresaProfile()
        {
            CreateMap<Adresa, AdresaDto>();
            CreateMap<AdresaDto, Adresa>();

        }
    }
}