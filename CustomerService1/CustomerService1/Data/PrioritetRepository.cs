using AutoMapper;
using CustomerService1.Entities;
using CustomerService1.Models;

namespace CustomerService1.Data
{
    public class PrioritetRepository : IPrioritetRepository
    {
        public static List<Prioritet> prioritets { get; set; } = new List<Prioritet>();
        private readonly IMapper mapper;
        private readonly KupacContext context;

        public PrioritetRepository(IMapper mapper, KupacContext context)
        {
           // FillData();
            this.mapper = mapper;
            this.context = context;

        }
        /*
        private void FillData()
        {
            prioritets.AddRange(new List<Prioritet>
            {
                new Prioritet
                {
                    PrioritetID= Guid.Parse("a215e4cb-a427-40cf-88b2-8488d140a939"),
                    OpisPrioriteta= "prioritet1",   
                },
                new Prioritet
                {
                    PrioritetID= Guid.Parse("1de13266-85e8-4120-8b1f-daacc32c5811"),
                    OpisPrioriteta= "prioritet2",
                }
            });
        }*/

        public List<Prioritet> getAllPrioritet()
        {
            return context.prioriteti.ToList();
        }

        public Prioritet getPrioritetById(Guid id)
        {
            return context.prioriteti.FirstOrDefault(p => p.PrioritetID == id);
        }

        public PrioritetConfirmation postPrioritet(Prioritet prioritet)
        {
            prioritet.PrioritetID = Guid.NewGuid();
            var noviP = context.prioriteti.Add(prioritet);
            return mapper.Map<PrioritetConfirmation>(prioritet);
        }

        public PrioritetConfirmation updatePrioritet(Prioritet prioritet)
        {
            Prioritet p = getPrioritetById(prioritet.PrioritetID);
            prioritet.PrioritetID = prioritet.PrioritetID;
            p.OpisPrioriteta = prioritet.OpisPrioriteta;

            return new PrioritetConfirmation
            {
                PrioritetID = p.PrioritetID,
                OpisPrioriteta=p.OpisPrioriteta
            };
        }

        public void deletePrioritet(Guid id)
        {
            Entities.Prioritet prioritet = getPrioritetById(id);
            context.prioriteti.Remove(prioritet);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
