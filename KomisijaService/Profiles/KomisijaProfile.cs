using AutoMapper;
using KomisijaService.Entities;
using KomisijaService.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KomisijaService.Profiles
{
    public class KomisijaProfile : Profile
    {
        public KomisijaProfile()
        {
            CreateMap<Komisija, KomisijaDto>();
            CreateMap<KomisijaUpdateDto, Komisija>();
            CreateMap<KomisijaCreationDto, Komisija>();
            CreateMap<Komisija, Komisija>();
        }
    }
}
