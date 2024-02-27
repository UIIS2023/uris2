using System;
using AuctionService.DtoModels;
using AuctionService.Entities;
using AuctionService.Repository;
using AutoMapper;
namespace AuctionService.Services
{
    public class JavnoNadmetanjeService : IJavnoNadmetanjeRepository
    {
        public static List<Entities.JavnoNadmetanje> javnoNadmetanjes { get; set; } = new List<Entities.JavnoNadmetanje>();
        private readonly JavnoNadmetanjeContext javnoNadmetanjeContext;
        private readonly IMapper mapper;

        public JavnoNadmetanjeService(IMapper mapper, JavnoNadmetanjeContext context)
        {
            this.javnoNadmetanjeContext = context;
            this.mapper = mapper;
        }
        public void deleteJavnoNadmetanje(Guid id)
        {
            Entities.JavnoNadmetanje jn = getJavnoNadmetanjeByID(id);
            javnoNadmetanjeContext.javnaNadmetanja.Remove(jn);
            
        }

        public List<Entities.JavnoNadmetanje> getJavnaNadmetanja()
        {
            return javnoNadmetanjeContext.javnaNadmetanja.ToList();
        }

        public Entities.JavnoNadmetanje getJavnoNadmetanjeByID(Guid id)
        {
            return javnoNadmetanjeContext.javnaNadmetanja.FirstOrDefault(jn => jn.javnoNadmetanjeID == id);
           
        }

        public JavnoNadmetanjeConformationDto postJavnoNadmetanje(Entities.JavnoNadmetanje jn)
        {
            jn.javnoNadmetanjeID = Guid.NewGuid();
            var novoJN = javnoNadmetanjeContext.Add(jn);
            return mapper.Map<JavnoNadmetanjeConformationDto>(novoJN.Entity);
            
        }

        public bool saveChanges()
        {
            return javnoNadmetanjeContext.SaveChanges() > 1;
        }

        public JavnoNadmetanjeConformationDto updateJavnoNadmetanje(Entities.JavnoNadmetanje jn)
        {
            throw new NotImplementedException();
        }
    }
}

