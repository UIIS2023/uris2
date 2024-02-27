using AutoMapper;
using PaymentService1.Entities;

namespace PaymentService1.Data
{
    public class KursnaListaRepository : IKursnaListaRepository
    {
        public static List<KursnaLista> kursnaListas { get; set; } = new List<KursnaLista>();
        private readonly IMapper mapper;
        private readonly UplataContext context;

        public KursnaListaRepository(IMapper mapper, UplataContext context)
        {
          
            this.mapper = mapper;
            this.context = context;
        }
        
        /// <summary>
        /// Metoda brise kurs
        /// </summary>
        /// <param name="id">Id kursa</param>
        public void deleteKurs(Guid id)
        {
            Entities.KursnaLista kursnaLista = getKursById(id);
            context.kursneListe.Remove(kursnaLista);
        }

        /// <summary>
        /// Metoda vraca sve kurseve
        /// </summary>
        /// <returns>Vraca listu kurseva</returns>
        public List<KursnaLista> getAllKurs()
        {
            return context.kursneListe.ToList();
        }
        /// <summary>
        /// Metoda vraca kurs sa zeljenim id-jem
        /// </summary>
        /// <param name="id">Id kursa</param>
        /// <returns>Vraca jedan id</returns>

        public KursnaLista getKursById(Guid id)
        {
            return context.kursneListe.FirstOrDefault(kl => kl.KursnaListaID == id);
        }
        /// <summary>
        /// Metoda kreira novi kurs
        /// </summary>
        /// <param name="kurs">Model kursa</param>
        /// <returns>Potvrda o kreiranom kursu</returns>

        public KursnaListaConfirmation postKurs(KursnaLista kurs)
        {
            kurs.KursnaListaID = Guid.NewGuid();
            var novaKL = context.kursneListe.Add(kurs);
            return mapper.Map<KursnaListaConfirmation>(kurs);
            
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
        /// Metoda modifikuje kurs
        /// </summary>
        /// <param name="kurs">Model kursa</param>
        /// <returns>Potvrda o modifikovanom kursu</returns>
        public KursnaListaConfirmation updateKurs(KursnaLista kurs)
        {
            KursnaLista kl = getKursById(kurs.KursnaListaID);
            kl.KursnaListaID = kurs.KursnaListaID;
            kl.datum= kurs.datum;
            kl.valuta = kurs.valuta;
            kl.vrednost = kurs.vrednost;
            return new KursnaListaConfirmation
            {
                KursnaListaID = kl.KursnaListaID,
                valuta = kl.valuta
            };
        }
    }
}
