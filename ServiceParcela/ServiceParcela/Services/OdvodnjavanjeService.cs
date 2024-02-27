using AutoMapper;
using ServiceParcela.DtoModels;
using ServiceParcela.Entities;
using ServiceParcela.Repositories;
using System.Xml.Linq;

namespace ServiceParcela.Services
{
    /// <summary>
    /// OdvodnjavanjeService
    /// </summary>
    ///
    public class OdvodnjavanjeService  : IOdvodnjavanjeRepository
    {
        /// <summary>
        /// OdvodnjavanjeService
        /// </summary>
        ///
        public static List<Odvodnjavanje> odvodnjavanjes { get; set; } = new List<Odvodnjavanje>();
        private readonly IMapper mapper;
        private readonly ParcelaContex context;
        /// <summary>
        /// OdvodnjavanjeService
        /// </summary>
        ///
        public OdvodnjavanjeService(IMapper mapper, ParcelaContex context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        /// <summary>
        /// deleteOdvodnjavanje
        /// </summary>
        ///
        public void deleteOdvodnjavanje(Guid id)
        {
            Entities.Odvodnjavanje odvodnjavanje = getOdvodnjavanjeByID(id);
            context.odvodnjavanja.Remove(odvodnjavanje);
        }
        /// <summary>
        /// getAllOdvodnjavanje
        /// </summary>
        ///
        public List<Odvodnjavanje> getAllOdvodnjavanje()
        {
            return context.odvodnjavanja.ToList();
        }
        /// <summary>
        /// getOdvodnjavanjeByID
        /// </summary>
        ///
        public Odvodnjavanje getOdvodnjavanjeByID(Guid id)
        {
            return context.odvodnjavanja.FirstOrDefault(odvodnjavanje => odvodnjavanje.odvodnjavanjeID == id);

        }
        /// <summary>
        /// postOdvodnjavanje
        /// </summary>
        ///
        public OdvodnjavanjeDto postOdvodnjavanje(Odvodnjavanje odvodnjavanje)
        {
            odvodnjavanje.odvodnjavanjeID = Guid.NewGuid();
            context.odvodnjavanja.Add(odvodnjavanje);
            return mapper.Map<OdvodnjavanjeDto>(odvodnjavanje);
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
        /// putOdvodnjavanje
        /// </summary>
        ///
        public OdvodnjavanjeDto putOdvodnjavanje(Odvodnjavanje odvodnjavanje)
        {
            throw new NotImplementedException();
        }
    }
}
