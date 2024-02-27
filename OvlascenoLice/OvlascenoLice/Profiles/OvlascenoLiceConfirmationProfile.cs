using AutoMapper;
using OvlascenoLice.Entities;
using OvlascenoLice.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvlascenoLice.Profiles
{
    public class OvlascenoLiceConfirmationProfile : Profile
    {
        public OvlascenoLiceConfirmationProfile()
        {
            CreateMap<OvlascenoLiceConfirmation, OvlascenoLiceConfirmationDto>();
            CreateMap<OvlascenoLiceConfirmationDto, OvlascenoLiceConfirmation>();

        }
    }
}