using Dokumenti_Service.Entities.Dokument;

namespace Dokumenti_Service.Data
{
    public interface IDokumentRepository
    {
        List<Dokument> GetAllDokuments();
        public Dokument GetDokumentEntityById(Guid dokumentid);
        Dokument CreateDokument(Dokument dokument);
        void UpdateDokument(Dokument dokument);
        void DeleteDokument(Guid dokumentid);
        bool SaveChanges();

    }
}
