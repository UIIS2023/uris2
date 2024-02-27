using Dokumenti_Service.Entities.Dokument;
using Dokumenti_Service.Entities.Zalba;

namespace Dokumenti_Service.Data
{
    public interface IZalbaRepository
    {
        List<Zalba> GetAllZalbas();
        public Zalba GetZalbaEntityById(Guid zalbaid);
        Zalba CreateZalba(Zalba zalba);
        void UpdateZalba(Zalba zalba);
        void DeleteZalba(Guid zalbaid);
        bool SaveChanges();
    }
}
