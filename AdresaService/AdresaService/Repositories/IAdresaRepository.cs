﻿using AdresaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaService.Repositories
{
    public interface IAdresaRepository
    {
        List<Adresa> GetAdresaList();

        Adresa GetAdresaById(Guid adresaId);

        Adresa CreateAdresa(Adresa adresa);

        void UpdateAdresa(Adresa adresa);

        void DeleteAdresa(Guid adresaId);
        bool SaveChanges();
    }
}
