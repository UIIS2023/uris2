using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UgovorZakupService.DtoModels;
using UgovorZakupService.Entities;

namespace UgovorZakupService.Repository
{
    public interface IUgovorOZakupuRepository
    {
        List<UgovorOZakupu> GetAllUgovorOZakupu();
        UgovorOZakupu GetUgovorOZakupuById(Guid id);
        UgovorOZakupuConfirmationDto CreateUgovorOZakupu(UgovorOZakupu ugovorOZakupu);
        UgovorOZakupuConfirmationDto UpdateUgovorOZakupu(UgovorOZakupu ugovorOZakupu);
        void DeleteUgovorOZakupu(Guid id);
        bool SaveChanges();
    }
}
