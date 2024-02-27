using AutoMapper;
using PaymentService1.Entities;

namespace PaymentService1.Data
{
    public class UplataRepository : IUplataRepository
    {
        public static List<Uplata> uplatas { get; set; } = new List<Uplata>();
        private readonly IMapper mapper;
        private readonly UplataContext context;

        public UplataRepository(IMapper mapper, UplataContext context)
        {
           
            this.mapper = mapper;
            this.context = context;
        }
        
        /// <summary>
        /// Metoda brise uplatu
        /// </summary>
        /// <param name="id">Id uplate</param>
        public void deleteUplata(Guid id)
        {
            Entities.Uplata uplata = getUplataById(id);
            context.uplate.Remove(uplata);
        }
        /// <summary>
        /// Metoda vraca sve uplate
        /// </summary>
        /// <returns>Lista uplata</returns>
        public List<Uplata> getAllUplate()
        {
            return context.uplate.ToList();
        }
        /// <summary>
        /// Metoda vraca uplatu sa zeljenim id-jem
        /// </summary>
        /// <param name="id">Id uplate</param>
        /// <returns>Vraca jednu uplatu</returns>
        public Uplata getUplataById(Guid id)
        {
            return context.uplate.FirstOrDefault(u => u.UplataID == id);
        }
        /// <summary>
        /// Metoda kreira novu uplatu
        /// </summary>
        /// <param name="uplata">Model uplate</param>
        /// <returns>Potvrda o kreiranoj uplati</returns>
        public UplataConfirmation postUplata(Uplata uplata)
        {
            uplata.UplataID = Guid.NewGuid();
            var novaU = context.uplate.Add(uplata);
            return mapper.Map<UplataConfirmation>(uplata);
            
        }
        /// <summary>
        /// Metoda cuva promene
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
        /// <summary>
        /// Metoda modifikuje uplatu
        /// </summary>
        /// <param name="uplata">Model uplate</param>
        /// <returns>Potvrda o modifikovanoj uplati</returns>
        public UplataConfirmation updateUplata(Uplata uplata)
        {
            Uplata u = getUplataById(uplata.UplataID);
            u.UplataID = uplata.UplataID;
            u.brojRacuna = uplata.brojRacuna;
            u.pozivNaBroj = uplata.pozivNaBroj;
            u.iznos = uplata.iznos;
            u.uplatilac = uplata.uplatilac;
            u.svrhaUplate = uplata.svrhaUplate;
            u.datum = uplata.datum;
            u.javnoNadmetanje = uplata.javnoNadmetanje;
            return new UplataConfirmation
            {
                UplataID = u.UplataID,
                brojRacuna = u.brojRacuna,
                iznos = u.iznos,
                uplatilac = u.uplatilac,
                datum = u.datum
            };
        }
    }
}
