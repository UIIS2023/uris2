using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UgovorZakupService.DtoModels;
using UgovorZakupService.Entities;
using UgovorZakupService.Repository;

namespace UgovorZakupService.Services
{
    public class TipGarancijeService : ITipGarancijeRepository
    {
        private readonly IMapper mapper;
        public static List<TipGarancije> tipoviGarancije { get; set; } = new List<TipGarancije>();
        public TipGarancijeService(IMapper mapper) 
        {
            this.mapper = mapper;
            FillData();
        }

        private static void FillData()
        {
            tipoviGarancije.AddRange(new List<TipGarancije>
            {
                new Entities.TipGarancije
                {
                    tipGarancijeID = Guid.Parse("{382E2313-F5AD-4931-A126-6194BDAA071A}"),
                    nazivTipaGarancije = "Tip 1"
                },
                new Entities.TipGarancije
                {
                    tipGarancijeID = Guid.Parse("{DACDC2B3-3480-42AB-B467-6AE0B75DF207}"),
                    nazivTipaGarancije = "Tip 2"
                }
            });
        }

        public TipGarancijeConfirmationDto CreateTipGarancije(TipGarancije tipGarancije)
        {
            tipGarancije.tipGarancijeID = Guid.NewGuid();
            tipoviGarancije.Add(tipGarancije);
            TipGarancijeConfirmationDto conformationDto = mapper.Map<TipGarancijeConfirmationDto>(tipGarancije);
            return conformationDto;
        }

        public void DeleteTipGarancije(Guid id)
        {
            Entities.TipGarancije statusTG = GetTipGarancijeById(id);
            tipoviGarancije.Remove(statusTG);
        }

        public List<TipGarancije> GetAllTipGarancije()
        {
            return (from tg in tipoviGarancije select tg).ToList();
        }

        public TipGarancije GetTipGarancijeById(Guid id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return tipoviGarancije.FirstOrDefault(tipGarancije => tipGarancije.tipGarancijeID == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public bool SaveChanges()
        {
            return true;
        }

        public TipGarancijeConfirmationDto UpdateTipGarancije(TipGarancije tipGarancije)
        {
            throw new NotImplementedException();
        }
    }
}
