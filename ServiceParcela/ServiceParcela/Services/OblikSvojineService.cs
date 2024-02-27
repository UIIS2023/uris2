using AutoMapper;
using ServiceParcela.DtoModels;
using ServiceParcela.Entities;
using ServiceParcela.Repositories;
using System.Xml.Linq;

namespace ServiceParcela.Services
{
    /// <summary>
    /// OblikSvojineService
    /// </summary>
    ///
    public class OblikSvojineService : IOblikSvojineRepository
    {
        /// <summary>
        /// OblikSvojineService
        /// </summary>
        ///
        public static List<OblikSvojine> oblikSvojines { get; set; } = new List<OblikSvojine>();
        private readonly IMapper mapper;
        private readonly ParcelaContex context;
        /// <summary>
        /// OblikSvojineService
        /// </summary>
        ///
        public OblikSvojineService(IMapper mapper, ParcelaContex context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        /// <summary>
        /// deleteOblikSvojine
        /// </summary>
        ///
        public void deleteOblikSvojine(Guid id)
        {
            Entities.OblikSvojine oblikSvojine = getOblikSvojineByID(id);
            context.obliciSvojine.Remove(oblikSvojine);
        }
        /// <summary>
        /// getAllOblikSvojine
        /// </summary>
        ///
        public List<OblikSvojine> getAllOblikSvojine()
        {
            return context.obliciSvojine.ToList();
        }/// <summary>
         /// getOblikSvojineByID
         /// </summary>
         ///

        public OblikSvojine getOblikSvojineByID(Guid id)
        {
            return context.obliciSvojine.FirstOrDefault(oblikSvojine => oblikSvojine.oblikSvojineID == id);

        }
        /// <summary>
        /// postOblikSvojine
        /// </summary>
        ///
        public OblikSvojineDto postOblikSvojine(OblikSvojine oblikSvojine)
        {
            oblikSvojine.oblikSvojineID = Guid.NewGuid();
            context.obliciSvojine.Add(oblikSvojine);
            return mapper.Map<OblikSvojineDto>(oblikSvojine);
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
        /// putOblikSvojine
        /// </summary>
        ///
        public OblikSvojineDto putOblikSvojine(OblikSvojine oblikSvojine)
        {
            throw new NotImplementedException();
        }
    }
}