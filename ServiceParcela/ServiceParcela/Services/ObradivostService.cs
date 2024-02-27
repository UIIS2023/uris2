using AutoMapper;
using ServiceParcela.DtoModels;
using ServiceParcela.Entities;
using ServiceParcela.Repositories;
using System.Xml.Linq;

namespace ServiceParcela.Services
{
    /// <summary>
    /// ObradivostService
    /// </summary>
    ///
    public class ObradivostService : IObradivostRepository
    {
        /// <summary>
        /// ObradivostService
        /// </summary>
        ///
        public static List<Obradivost> obradivosts { get; set; } = new List<Obradivost>();
        private readonly IMapper mapper;
        private readonly ParcelaContex context;
        /// <summary>
        /// ObradivostService
        /// </summary>
        ///
        public ObradivostService(IMapper mapper, ParcelaContex context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        /// <summary>
        /// deleteObradivost
        /// </summary>
        ///
        public void deleteObradivost(Guid id)
        {
            Entities.Obradivost obradivost = getObradivostByID(id);
            context.obradivosti.Remove(obradivost);
        }
        /// <summary>
        /// getAllObradivost
        /// </summary>
        ///
        public List<Obradivost> getAllObradivost()
        {
            return context.obradivosti.ToList();
        }
        /// <summary>
        /// getObradivostByID
        /// </summary>
        ///
        public Obradivost getObradivostByID(Guid id)
        {
            return context.obradivosti.FirstOrDefault(obradivost => obradivost.obradivostID == id);

        }
        /// <summary>
        /// postObradivost
        /// </summary>
        ///
        public ObradivostDto postObradivost(Obradivost obradivost)
        {
            obradivost.obradivostID = Guid.NewGuid();
            context.obradivosti.Add(obradivost);
            return mapper.Map<ObradivostDto>(obradivost);
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
        /// putObradivost
        /// </summary>
        ///
        public ObradivostDto putObradivost(Obradivost obradivost)
        {
            throw new NotImplementedException();
        }
    }
}
