﻿using AutoMapper;
using KomisijaService.Entities;
using KomisijaService.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KomisijaService.Profiles
{
    public class ClanoviConfirmationProfile : Profile
    {
        public ClanoviConfirmationProfile()
        {
            CreateMap<Clanovi, ClanoviConfirmationDto>();
        }
    }
}
