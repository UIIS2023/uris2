using AutoMapper;
using Dokumenti_Service.Entities.Dokument;
using Dokumenti_Service.Entities;
using Dokumenti_Service.Entities.Zalba;
using Dokumenti_Service.Models;

namespace Dokumenti_Service.Data
{
    public class TipZalbeRepository : ITipZalbeRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;



        public TipZalbeRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public TipZalbe CreateTipZalbe(TipZalbe tipZalbe)
        {
            tipZalbe.tipZalbeId= Guid.NewGuid();
            var createdTipZalbe = context.TipZalbe.Add(tipZalbe);
            return mapper.Map<TipZalbe>(createdTipZalbe.Entity);
        }



        public void DeleteTipZalbe(Guid tipZalbeid)
        {
            var tipZalbeDel = GetTipZalbeEntityById(tipZalbeid);
            context.Remove(tipZalbeDel);
        }

        public List<TipZalbe> GetAllTipZalbes()
        {
            return context.TipZalbe.ToList();
        }

        public TipZalbe GetTipZalbeEntityById(Guid tipZalbeid)
        {
            return context.TipZalbe.FirstOrDefault(e => e.tipZalbeId == tipZalbeid);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }



        public void UpdateTipZalbe(TipZalbe tipZalbe)
        {
            
        }
    }
}
