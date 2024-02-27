using System;
using AuctionService.DtoModels;
using AuctionService.Entities;
using AuctionService.Repository;
using AutoMapper;

namespace AuctionService.Services
{
	public class TipNadmetanjaService : ITipNadmetanjaRepository 
	{
        public static List<TipJavnogNadmetanja> tipJavnogNadmetanjas { get; set; } = new List<TipJavnogNadmetanja>();
        private readonly JavnoNadmetanjeContext context;
        private readonly IMapper mapper;

		public TipNadmetanjaService(IMapper mapper, JavnoNadmetanjeContext context)
		{
            this.mapper = mapper;
            this.context = context;
		}



        public void deleteTipJavnogNadmetanja(Guid id)
        {
            Entities.TipJavnogNadmetanja tipJn = getTipJavnogNadmetanjaById(id);
            context.tipoviNadmetanja.Remove(tipJn);
        }

        public List<TipJavnogNadmetanja> getAllTipoviJavnogNadmetanja()
        {
            return context.tipoviNadmetanja.ToList();
            
        }

        public TipJavnogNadmetanja getTipJavnogNadmetanjaById(Guid id)
        {
            return context.tipoviNadmetanja.FirstOrDefault(tipJn => tipJn.tipJavnogNadmetanjaID == id);          
        }

        public TipJavnogNadmetanjaConformationDto postTipJavnogNadmetanja(TipJavnogNadmetanja tipJN)
        {
            tipJN.tipJavnogNadmetanjaID = Guid.NewGuid();
            var noviTip = context.tipoviNadmetanja.Add(tipJN);
            return mapper.Map<TipJavnogNadmetanjaConformationDto>(tipJN);

       }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public TipJavnogNadmetanjaConformationDto updateTipJavnogNadmetanja(TipJavnogNadmetanja tipJN)
        {
            throw new NotImplementedException();
        }
    }
}

