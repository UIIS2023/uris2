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
    public class PredsednikService : IPredsednikRepository
    {
        private readonly KomisijaContext context;
        private readonly IMapper mapper;

        public PredsednikService(KomisijaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public PredsednikConfirmationDto CreatePredsednik(Predsednik predsednik)
        {
            var createdEntity = context.Add(predsednik);
            return mapper.Map<PredsednikConfirmationDto>(createdEntity.Entity);
        }

        public void DeletePredsednik(Guid predsednikId)
        {
            var predsednik = GetPredsednikById(predsednikId);
            context.Remove(predsednik);
        }

        public List<Predsednik> GetAllPredsednik()
        {
            return context.Predsednik.ToList();
        }

        public Predsednik GetPredsednikById(Guid predsednikId)
        {
            return context.Predsednik.FirstOrDefault(r => r.predsednikID == predsednikId);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

    }
}
