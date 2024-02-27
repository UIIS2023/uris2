using Dokumenti_Service.Entities.Oglas;

namespace Dokumenti_Service.Data
{
    public interface IOglasRepository
    {
        List<Oglas> GetAllOglases();
        public Oglas GetOglasEntityById(Guid oglasid);
        Oglas CreateOglas(Oglas oglas);
        void UpdateOglas(Oglas oglas);
        void DeleteOglas(Guid oglasid);
        bool SaveChanges();
    }
}
