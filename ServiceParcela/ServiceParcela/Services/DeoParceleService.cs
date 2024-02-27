using AutoMapper;
using ServiceParcela.DtoModels;
using ServiceParcela.Entities;
using ServiceParcela.Repositories;
using System.Xml.Linq;

namespace ServiceParcela.Services
{
    /// <summary>
    /// DeoParceleService
    /// </summary>
    ///
    public class DeoParceleService  : IDeoParceleRepository
    {
        /// <summary>
        /// DeoParceleService
        /// </summary>
        ///
        public static List<DeoParcele> deoParceles { get; set; } = new List<DeoParcele>();
        private readonly IMapper mapper;
        private readonly ParcelaContex context;

        /// <summary>
        /// DeoParceleService
        /// </summary>
        ///
        public DeoParceleService(IMapper mapper, ParcelaContex context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        /// <summary>
        /// deleteDeoParcele
        /// </summary>
        ///
        public void deleteDeoParcele(Guid id)
        {
            Entities.DeoParcele deoParcele = getDeoParceleByID(id);
            context.deloviParcele.Remove(deoParcele);
        }
        /// <summary>
        /// getAllDeoParcele
        /// </summary>
        ///
        public List<DeoParcele> getAllDeoParcele()
        {
            return context.deloviParcele.ToList();
        }
        /// <summary>
        /// getDeoParceleByID
        /// </summary>
        ///
        public DeoParcele getDeoParceleByID(Guid id)
        {
            return context.deloviParcele.FirstOrDefault(deoParcele => deoParcele.deoParceleID == id);


        }
        /// <summary>
        /// postDeoParcele
        /// </summary>
        ///
        public DeoParceleDto postDeoParcele(DeoParcele deoParcele)
        {
            deoParcele.deoParceleID = Guid.NewGuid();
            var novoDP = context.Add(deoParcele);
            return mapper.Map<DeoParceleDto>(novoDP.Entity);
        }
        /// <summary>
        /// saveChanges
        /// </summary>
        ///
        public bool saveChanges()
        {
            return context.SaveChanges() > 1;
        }
        /// <summary>
        /// putDeoParcele
        /// </summary>
        ///
        public DeoParceleDto putDeoParcele(DeoParcele deoParcele)
        {
            throw new NotImplementedException();
        }
    }
}
