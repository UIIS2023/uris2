using AutoMapper;
using Dokumenti_Service.Entities.Dokument;
using Dokumenti_Service.Entities;
using Dokumenti_Service.Entities.Zalba;
using Dokumenti_Service.Models;

namespace Dokumenti_Service.Data
{
    public class RadnjaNaOsnovuZalbeRepository : IRadnjaNaOsnovuZalbeRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;



        public RadnjaNaOsnovuZalbeRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public RadnjaNaOsnovuZalbe CreateRadnjaNaOsnovuZalbe(RadnjaNaOsnovuZalbe radnjaNaOsnovuZalbe)
        {
            radnjaNaOsnovuZalbe.radnjaNaOsnovuZalbeId = Guid.NewGuid();
            var createdRadnjaNaOsnovuZalbe = context.Add(radnjaNaOsnovuZalbe);
            return mapper.Map<RadnjaNaOsnovuZalbe>(createdRadnjaNaOsnovuZalbe.Entity);
        }



        public void DeleteRadnjaNaOsnovuZalbe(Guid radnjaNaOsnovuZalbeid)
        {
            var radnjaNaOsnovuZalbeDel = GetRadnjaNaOsnovuZalbeEntityById(radnjaNaOsnovuZalbeid);
            context.Remove(radnjaNaOsnovuZalbeDel);
        }

        public List<RadnjaNaOsnovuZalbe> GetAllRadnjaNaOsnovuZalbes()
        {
            return context.Radnja.ToList();
        }

        public RadnjaNaOsnovuZalbe GetRadnjaNaOsnovuZalbeEntityById(Guid radnjaNaOsnovuZalbeid)
        {
            return context.Radnja.FirstOrDefault(e => e.radnjaNaOsnovuZalbeId == radnjaNaOsnovuZalbeid);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
        public void UpdateRadnjaNaOsnovuZalbe(RadnjaNaOsnovuZalbe radnjaNaOsnovuZalbe)
        {
           
        }
    }
}
