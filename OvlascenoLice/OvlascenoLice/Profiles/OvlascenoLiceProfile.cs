using AutoMapper;
using OvlascenoLice.Entities;
using OvlascenoLice.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvlascenoLice.Profiles
{
    public class OvlascenoLiceProfile : Profile
    {
        public OvlascenoLiceProfile()
        {

            CreateMap<OvlascenoLiceModel, OvlascenoLiceDto>();
            CreateMap<OvlascenoLiceDto, OvlascenoLiceModel>();
        }
    }
}