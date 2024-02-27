using AutoMapper;
using Dokumenti_Service.Entities;
using Dokumenti_Service.Entities.Dokument;
using Dokumenti_Service.Entities.Oglas;

namespace Dokumenti_Service.Data
{
    public class DokumentRepository : IDokumentRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;



        public DokumentRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public Dokument CreateDokument(Dokument dokument)
        {
            dokument.dokumentId = Guid.NewGuid();
            var createdDokument = context.Add(dokument);
            return mapper.Map<Dokument>(createdDokument.Entity);
        }



        public void DeleteDokument(Guid dokumentid)
        {
            var dokumentDel = GetDokumentEntityById(dokumentid);
            context.Remove(dokumentDel);
        }

        public List<Dokument> GetAllDokuments()
        {
            return context.Dokument.ToList();
        }

        public Dokument GetDokumentEntityById(Guid dokumentid)
        {
            return context.Dokument.FirstOrDefault(e => e.dokumentId == dokumentid);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

       

       public  void UpdateDokument(Dokument dokument)
        {
            
        }
    }
}
