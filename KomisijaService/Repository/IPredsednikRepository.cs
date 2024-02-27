using KomisijaService.DtoModels;
using KomisijaService.Entities;

namespace KomisijaService.Repository
{
    public interface IPredsednikRepository
    {
        List<Predsednik> GetAllPredsednik();
        Predsednik GetPredsednikById(Guid predsednikId);
        PredsednikConfirmationDto CreatePredsednik(Predsednik predsednik);
        void DeletePredsednik(Guid predsednikId);
        bool SaveChanges();
    }
}
