using Dokumenti_Service.Entities.Oglas;

namespace Dokumenti_Service.Data
{
    public interface IOglasnaTablaRepository
    {
        List<OglasnaTabla> GetAllOglasnaTablas();
        public OglasnaTabla GetOglasnaTablaEntityById(Guid oglasnaTablaid);
        OglasnaTabla CreateOglasnaTabla(OglasnaTabla oglasnaTabla);
        void UpdateOglasnaTabla(OglasnaTabla oglasnaTabla);
        void DeleteOglasnaTabla(Guid oglasnaTablaid);
        bool SaveChanges();
    }
}
