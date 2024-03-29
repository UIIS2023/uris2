﻿using AutoMapper;
using AdresaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdresaService.Repositories;

namespace AdresaService.Services
{
    public class DrzavaRepository : IDrzavaRepository
    {
        private readonly MestoContext context;
        private readonly IMapper mapper;
        public DrzavaRepository(MestoContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
        public Drzava CreateDrzava(Drzava drzava)
        {
            var createdEntity = context.Add(drzava);
            context.SaveChanges();
            return mapper.Map<Drzava>(createdEntity.Entity);
        }

        public void DeleteDrzava(Guid drzavaId)
        {
            var drzava = GetDrzavaById(drzavaId);
            context.Remove(drzava);
            context.SaveChanges();
        }

        public Drzava GetDrzavaById(Guid drzavaId)
        {
            return context.Drzava.FirstOrDefault(d => d.DrzavaId == drzavaId);
        }

        public List<Drzava> GetDrzavaList()
        {
            return context.Drzava.ToList();
        }

        public void UpdateDrzava(Drzava drzava)
        {
            //nije potrebno posebno implementirati update
        }
    }
}