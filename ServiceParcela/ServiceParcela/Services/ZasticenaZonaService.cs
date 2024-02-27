using AutoMapper;
using ServiceParcela.DtoModels;
using ServiceParcela.Entities;
using ServiceParcela.Repositories;
using System.Xml.Linq;

namespace ServiceParcela.Services
{
    /// <summary>
    /// ZasticenaZonaService
    /// </summary>
    ///
    public class ZasticenaZonaService : IZasticenaZonaRepository
    {
        /// <summary>
        /// ZasticenaZonaService
        /// </summary>
        ///
        public static List<ZasticenaZona> zasticenaZonas { get; set; } = new List<ZasticenaZona>();
        private readonly IMapper mapper;
        private readonly ParcelaContex context;
        /// <summary>
        /// ZasticenaZonaService
        /// </summary>
        ///
        public ZasticenaZonaService(IMapper mapper, ParcelaContex context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        /// <summary>
        /// deleteZasticenaZona
        /// </summary>
        ///
        public void deleteZasticenaZona(Guid id)
        {
            Entities.ZasticenaZona zasticenaZona = getZasticenaZonaByID(id);
            context.zasticeneZone.Remove(zasticenaZona);
        }
        /// <summary>
        /// getAllZasticenaZona
        /// </summary>
        ///
        public List<ZasticenaZona> getAllZasticenaZona()
        {
            return context.zasticeneZone.ToList();
        }
        /// <summary>
        /// getZasticenaZonaByID
        /// </summary>
        ///
        public ZasticenaZona getZasticenaZonaByID(Guid id)
        {
            return context.zasticeneZone.FirstOrDefault(zasticenaZona => zasticenaZona.zasticenaZonaID == id);

        }
        /// <summary>
        /// postZasticenaZona
        /// </summary>
        ///
        public ZasticenaZonaDto postZasticenaZona(ZasticenaZona zasticenaZona)
        {
            zasticenaZona.zasticenaZonaID = Guid.NewGuid();
            context.zasticeneZone.Add(zasticenaZona);
            return mapper.Map<ZasticenaZonaDto>(zasticenaZona);
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
        /// putZasticenaZona
        /// </summary>
        ///
        public ZasticenaZonaDto putZasticenaZona(ZasticenaZona zasticenaZona)
        {
            throw new NotImplementedException();
        }
    }
}
