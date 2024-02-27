using Dokumenti_Service.Entities.Dokument;
using Dokumenti_Service.Entities.Zalba;

namespace Dokumenti_Service.Data
{
    public interface IRadnjaNaOsnovuZalbeRepository
    {
        List<RadnjaNaOsnovuZalbe> GetAllRadnjaNaOsnovuZalbes();
        public RadnjaNaOsnovuZalbe GetRadnjaNaOsnovuZalbeEntityById(Guid radnjaNaOsnovuZalbeid);
        RadnjaNaOsnovuZalbe CreateRadnjaNaOsnovuZalbe(RadnjaNaOsnovuZalbe radnjaNaOsnovuZalbe);
        void UpdateRadnjaNaOsnovuZalbe(RadnjaNaOsnovuZalbe radnjaNaOsnovuZalbe);
        void DeleteRadnjaNaOsnovuZalbe(Guid radnjaNaOsnovuZalbeid);
        bool SaveChanges();
    }
}
