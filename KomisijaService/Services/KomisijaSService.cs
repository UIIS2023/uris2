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
    public class KomisijaSService : IKomisijaRepository
    {
        private readonly KomisijaContext context;
        private readonly IMapper mapper;

        public KomisijaSService(KomisijaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        } 

        public KomisijaConfirmationDto CreateKomisija(Komisija komisija)
        {
            var createdEntity = context.Add(komisija);
            return mapper.Map<KomisijaConfirmationDto>(createdEntity.Entity);
        }

        public void DeleteKomisija(Guid komisijaId)
        {
            var komisija = GetKomisijaById(komisijaId);
            context.Remove(komisija);
        }

        public List<Komisija> GetAllKomisija(Guid? predsednikID = null)
        {
            return context.Komisija
                .Where(r => (predsednikID == null || r.predsednikID == predsednikID))
                .ToList();
        }

        public Komisija GetKomisijaById(Guid komisijaID)
        {
            return context.Komisija.FirstOrDefault(r => r.komisijaID == komisijaID);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateKomisija(Komisija komisija)
        {
            //Entity framework core prati entitet pa nema potrebe za implementacijom
        }
    }
}
