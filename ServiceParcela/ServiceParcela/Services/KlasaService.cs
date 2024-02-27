using AutoMapper;
using ServiceParcela.DtoModels;
using ServiceParcela.Entities;
using ServiceParcela.Repositories;
using System.Xml.Linq;

namespace ServiceParcela.Services
{
    /// <summary>
    /// KlasaService
    /// </summary>
    ///
    public class KlasaService  : IKlasaRepository
    {
        /// <summary>
        /// KlasaService
        /// </summary>
        ///
        public static List<Klasa> klasas { get; set; } = new List<Klasa>();
        private readonly IMapper mapper;
        private readonly ParcelaContex context;

        /// <summary>
        /// KlasaService
        /// </summary>
        ///
        public KlasaService(IMapper mapper, ParcelaContex context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        /// <summary>
        /// deleteKlasa
        /// </summary>
        ///
        public void deleteKlasa(Guid id)
        {
            Entities.Klasa klasa = getKlasaByID(id);
            context.klase.Remove(klasa);
        }
        /// <summary>
        /// getAllKlasa
        /// </summary>
        ///
        public List<Klasa> getAllKlasa()
        {
            return context.klase.ToList();
        }
        /// <summary>
        /// getKlasaByID
        /// </summary>
        ///
        public Klasa getKlasaByID(Guid id)
        {
            return context.klase.FirstOrDefault(klasa => klasa.klasaID == id);

        }
        /// <summary>
        /// postKlasa
        /// </summary>
        ///
        public KlasaDto postKlasa(Klasa klasa)
        {
            klasa.klasaID = Guid.NewGuid();
            context.klase.Add(klasa);
            return mapper.Map<KlasaDto>(klasa);
        }
        /// <summary>
        /// saveChanges
        /// </summary>
        ///
        public bool saveChanges()
        {
            return context.SaveChanges() > 0;
        }
        /// <summary>
        /// putKlasa
        /// </summary>
        ///
        public KlasaDto putKlasa(Klasa klasa)
        {
            throw new NotImplementedException();
        }
    }
}
