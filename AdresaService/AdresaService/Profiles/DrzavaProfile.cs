using AutoMapper;
using AdresaService.Entities;
using AdresaService.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaService.Profiles
{
    public class DrzavaProfile : Profile
    {
        public DrzavaProfile()
        {
            CreateMap<Drzava, DrzavaDto>();
            CreateMap<DrzavaDto, Drzava>();
        }
    }
}