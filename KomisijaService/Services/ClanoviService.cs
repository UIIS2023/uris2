using AutoMapper;
using KomisijaService.Repository;
using KomisijaService.Entities;
using KomisijaService.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KomisijaService.Services
{
    public class ClanoviService : IClanoviRepository
    {
        private readonly KomisijaContext context;
        private readonly IMapper mapper;

        public ClanoviService(KomisijaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public ClanoviConfirmationDto CreateClanovi(Clanovi clanovi)
        {
            var createdEntity = context.Add(clanovi);
            return mapper.Map<ClanoviConfirmationDto>(createdEntity.Entity);
        }

        public void DeleteClanovi(Guid clanoviId)
        {
            var clanovi = GetClanoviById(clanoviId);
            context.Remove(clanovi);
        }

        public List<Clanovi> GetAllClanovi(Guid? komisijaId = null)
        {
            return context.Clanovi
                 .Where(r => (komisijaId == null || r.komisijaID == komisijaId))
                 .ToList();
        }

        public Clanovi GetClanoviById(Guid clanoviId)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return context.Clanovi.FirstOrDefault(r => r.clanoviID == clanoviId);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateClanovi(Clanovi clanovi)
        {
            //Entity framework core prati entitet pa nema potrebe za implementacijom
        }
    }
}
