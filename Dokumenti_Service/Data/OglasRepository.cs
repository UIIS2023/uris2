using AutoMapper;
using Dokumenti_Service.Entities.Dokument;
using Dokumenti_Service.Entities;
using Dokumenti_Service.Entities.Oglas;
using Dokumenti_Service.Entities.Zalba;

namespace Dokumenti_Service.Data
{
    public class OglasRepository : IOglasRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;



        public OglasRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public Oglas CreateOglas(Oglas oglas)
        {
            oglas.oglasId = Guid.NewGuid();
            var createdOglas = context.Add(oglas);
            return mapper.Map<Oglas>(createdOglas.Entity);
        }



        public void DeleteOglas(Guid oglasid)
        {
            var oglasDel = GetOglasEntityById(oglasid);
            context.Remove(oglasDel);
        }

        public List<Oglas> GetAllOglases()
        {
            return context.Oglas.ToList();
        }

        public Oglas GetOglasEntityById(Guid oglasid)
        {
            return context.Oglas.FirstOrDefault(e => e.oglasId == oglasid);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }



        public void UpdateOglas(Oglas oglas)
        {
            
        }
    }
}
