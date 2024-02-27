using KomisijaService.DtoModels;
using KomisijaService.Entities;

namespace KomisijaService.Repository
{
    public interface IClanoviRepository
    {
        List<Clanovi> GetAllClanovi(Guid? komisijaId = null);
        Clanovi GetClanoviById(Guid clanoviId);
        ClanoviConfirmationDto CreateClanovi(Clanovi clanovi);
        void UpdateClanovi(Clanovi clanovi);
        void DeleteClanovi(Guid clanoviId);
        bool SaveChanges();
    }
}
