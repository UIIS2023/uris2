using KomisijaService.DtoModels;
using KomisijaService.Entities;

namespace KomisijaService.Repository
{
    public interface IKomisijaRepository
    {
        List<Komisija> GetAllKomisija(Guid? predsednikID = null);
        Komisija GetKomisijaById(Guid komisijaID);
        KomisijaConfirmationDto CreateKomisija(Komisija komisija);
        void UpdateKomisija(Komisija komisija);
        void DeleteKomisija(Guid komisijaId);
        bool SaveChanges();
    }
}
