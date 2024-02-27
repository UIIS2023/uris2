using System;
using AuctionService.DtoModels;
using AuctionService.Entities;
using AuctionService.Repository;
using AutoMapper;

namespace AuctionService.Services
{
    public class StatusNadmetanjaService : IStatusNadmetanjaRepository
    {
        private readonly JavnoNadmetanjeContext context;
        private readonly IMapper mapper;
        public static List<StatusNadmetanja> statusNadmetanjas { get; set; } = new List<StatusNadmetanja>();

        public StatusNadmetanjaService(IMapper mapper, JavnoNadmetanjeContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public void deleteStatusNadmetanja(Guid id)
        {
            Entities.StatusNadmetanja statusJN = getStatusNadmetanjaByID(id);
            context.statusiNadmetanja.Remove(statusJN);

        }

        public List<StatusNadmetanja> getAllStatusiNadmetanja()
        {
            return context.statusiNadmetanja.ToList();
        }

        public StatusNadmetanja getStatusNadmetanjaByID(Guid id)
        {
            return context.statusiNadmetanja.FirstOrDefault(statusJN => statusJN.statusNadmetanjaID == id);
           
        }

        public StatusNadmetanjaConformationDto postStatusNadmetanja(StatusNadmetanja status)
        {
            status.statusNadmetanjaID = Guid.NewGuid();
            var noviStatus = context.statusiNadmetanja.Add(status);
            return mapper.Map<StatusNadmetanjaConformationDto>(noviStatus.Entity);
           
            
        }
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public StatusNadmetanjaConformationDto updateStatusNadmetanja(StatusNadmetanja status)
        {
            throw new NotImplementedException();
        }
    }
}

