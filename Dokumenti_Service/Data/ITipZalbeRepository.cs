using Dokumenti_Service.Entities.Dokument;
using Dokumenti_Service.Entities.Zalba;

namespace Dokumenti_Service.Data
{
    public interface ITipZalbeRepository
    {
        List<TipZalbe> GetAllTipZalbes();
        public TipZalbe GetTipZalbeEntityById(Guid tipZalbeid);
        TipZalbe CreateTipZalbe(TipZalbe tipZalbe);
        void UpdateTipZalbe(TipZalbe tipZalbe);
        void DeleteTipZalbe(Guid tipZalbeid);
        bool SaveChanges();
    }
}
