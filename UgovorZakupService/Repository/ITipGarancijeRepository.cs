using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UgovorZakupService.DtoModels;
using UgovorZakupService.Entities;

namespace UgovorZakupService.Repository
{
    public interface ITipGarancijeRepository
    {
        List<TipGarancije> GetAllTipGarancije();
        TipGarancije GetTipGarancijeById(Guid id);
        TipGarancijeConfirmationDto CreateTipGarancije(TipGarancije tipGarancije);
        TipGarancijeConfirmationDto UpdateTipGarancije(TipGarancije tipGarancije);
        void DeleteTipGarancije(Guid id);
        bool SaveChanges();
    }
}
