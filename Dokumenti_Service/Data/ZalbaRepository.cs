using AutoMapper;
using Dokumenti_Service.Entities.Dokument;
using Dokumenti_Service.Entities;
using Dokumenti_Service.Entities.Zalba;
using Dokumenti_Service.Models;

namespace Dokumenti_Service.Data
{
    public class ZalbaRepository : IZalbaRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;



        public ZalbaRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public Zalba CreateZalba(Zalba zalba)
        {
            zalba.zalbaId = Guid.NewGuid();
            var createdZalba = context.Add(zalba);
            return mapper.Map<Zalba>(createdZalba.Entity);
        }



        public void DeleteZalba(Guid zalbaid)
        {
            var zalbaDel = GetZalbaEntityById(zalbaid);
            context.Remove(zalbaDel);
        }

        public List<Zalba> GetAllZalbas()
        {
            return context.Zalba.ToList();
        }

        public Zalba GetZalbaEntityById(Guid zalbaid)
        {
            return context.Zalba.FirstOrDefault(e => e.zalbaId== zalbaid);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }



        public void UpdateZalba(Zalba zalba)
        {
            
        }
    }
}
