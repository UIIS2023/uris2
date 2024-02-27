using AdresaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaService.Repositories
{
    public interface IDrzavaRepository
    {
        List<Drzava> GetDrzavaList();

        Drzava GetDrzavaById(Guid drzavaId);

        Drzava CreateDrzava(Drzava drzava);

        void UpdateDrzava(Drzava drzava);

        void DeleteDrzava(Guid drzavaId);
        bool SaveChanges();
    }
}
