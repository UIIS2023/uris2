using AutoMapper;
using Dokumenti_Service.Entities.Oglas;
using Dokumenti_Service.Entities;
using Dokumenti_Service.Models;

namespace Dokumenti_Service.Data
{
    public class OglasnaTablaRepository : IOglasnaTablaRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;



        public OglasnaTablaRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public OglasnaTabla CreateOglasnaTabla(OglasnaTabla oglasnaTabla)
        {
            oglasnaTabla.oglasnaTablaId = Guid.NewGuid();
            List<Guid> Oglasi = oglasnaTabla.oglasi;
            if (Oglasi != null)
            {
                foreach (var oglasId in Oglasi)
                {
                    var o = new OglasnaTablaOglas
                    {
                        oglasnaTablaId = oglasnaTabla.oglasnaTablaId,
                        oglasId= oglasId  
                    };
                     context.OglasnaTablaOglas.Add(o);
                }
            }
            var createdOglasnaTabla = context.Add(oglasnaTabla);
            return mapper.Map<OglasnaTabla>(createdOglasnaTabla.Entity);

        }



        public void DeleteOglasnaTabla(Guid oglasnaTablaid)
        {
            var oglasnaTablaDel = GetOglasnaTablaEntityById(oglasnaTablaid);
            context.Remove(oglasnaTablaDel);
        }

        public List<OglasnaTabla> GetAllOglasnaTablas()
        {
            var ogTab = context.OglasnaTabla.ToList();
            foreach (var oglasnaTabla in ogTab)
            {
                oglasnaTabla.oglasi =  context.OglasnaTablaOglas.Where(ot => ot.oglasnaTablaId == oglasnaTabla.oglasnaTablaId).Select(o => o.oglasId).ToList();
 
            }
            return ogTab;
        }

        public OglasnaTabla GetOglasnaTablaEntityById(Guid oglasnaTablaid)
        {
          var oglasnaTab = context.OglasnaTabla.FirstOrDefault(e => e.oglasnaTablaId == oglasnaTablaid);
            if (oglasnaTab is not null)
            {
                oglasnaTab.oglasi =  context.OglasnaTablaOglas.Where(ot => ot.oglasnaTablaId == oglasnaTab.oglasnaTablaId).Select(o => o.oglasId).ToList();
                
            }
            return oglasnaTab;
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }



        public void UpdateOglasnaTabla(OglasnaTabla oglasnaTabla)
        {
            
        }
    }
}
