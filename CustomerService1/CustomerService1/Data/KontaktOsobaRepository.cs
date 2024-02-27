using AutoMapper;
using CustomerService1.Entities;
using CustomerService1.Models;

namespace CustomerService1.Data
{
    public class KontaktOsobaRepository : IKontaktOsobaRepository
    {
        public static List<KontaktOsoba> kontaktOsobas { get; set; } = new List<KontaktOsoba>();
        private readonly IMapper mapper;
        private readonly KupacContext context;


        public KontaktOsobaRepository(IMapper mapper, KupacContext context)
        {
           
            this.mapper = mapper;
            this.context = context;
        }
        
        public void deleteKontaktOsoba(Guid id)
        {
            Entities.KontaktOsoba kontakt = getKontaktOsobaById(id);
            context.kontaktOsoba.Remove(kontakt);
        }

        public List<KontaktOsoba> getAllKontaktOsobe()
        {
            return context.kontaktOsoba.ToList();
        }

        public KontaktOsoba getKontaktOsobaById(Guid id)
        {
            return context.kontaktOsoba.FirstOrDefault(ko => ko.KontaktOsobaID == id);
        }

        public KontaktOsobaConfirmation postKontaktOsoba(KontaktOsoba kontaktOsoba)
        {
            kontaktOsoba.KontaktOsobaID = Guid.NewGuid();
            var novaKO = context.kontaktOsoba.Add(kontaktOsoba);
            return mapper.Map<KontaktOsobaConfirmation>(kontaktOsoba);

        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public KontaktOsobaConfirmation updateKontaktOsoba(KontaktOsoba kontaktOsoba)
        {
            
            KontaktOsoba ko = getKontaktOsobaById(kontaktOsoba.KontaktOsobaID);
             ko.KontaktOsobaID = kontaktOsoba.KontaktOsobaID;
             ko.Ime = kontaktOsoba.Ime;
             ko.Prezime = kontaktOsoba.Prezime;
             ko.Funkcija = kontaktOsoba.Funkcija;
             ko.Telefon = kontaktOsoba.Telefon;
             return new KontaktOsobaConfirmation
             {
                 KontaktOsobaID = ko.KontaktOsobaID,
                 Ime = ko.Ime,
                 Prezime = ko.Prezime
             }; 
        }
    }
}
