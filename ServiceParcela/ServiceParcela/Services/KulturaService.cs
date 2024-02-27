using AutoMapper;
using ServiceParcela.DtoModels;
using ServiceParcela.Entities;
using ServiceParcela.Repositories;
using System.Xml.Linq;

namespace ServiceParcela.Services
{
    /// <summary>
    /// KulturaService
    /// </summary>
    ///
    public class KulturaService  : IKulturaRepository
    {
        /// <summary>
        /// KulturaService
        /// </summary>
        ///
        public static List<Kultura> kulturas { get; set; } = new List<Kultura>();
        private readonly IMapper mapper;
        private readonly ParcelaContex context;
        /// <summary>
        /// KulturaService
        /// </summary>
        ///
        public KulturaService(IMapper mapper, ParcelaContex context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        /// <summary>
        /// deleteKultura
        /// </summary>
        ///      
        public void deleteKultura(Guid id)
        {
            Entities.Kultura kultura = getKulturaByID(id);
            context.kulture.Remove(kultura);
        }
        /// <summary>
        /// getAllKultura
        /// </summary>
        ///
        public List<Kultura> getAllKultura()
        {
            return context.kulture.ToList();
        }
        /// <summary>
        /// getKulturaByID
        /// </summary>
        ///
        public Kultura getKulturaByID(Guid id)
        {
            return context.kulture.FirstOrDefault(kultura => kultura.kulturaID == id);

        }
        /// <summary>
        /// postKultura
        /// </summary>
        ///
        public KulturaDto postKultura(Kultura kultura)
        {
            kultura.kulturaID = Guid.NewGuid();
            context.kulture.Add(kultura);
            return mapper.Map<KulturaDto>(kultura);
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
        /// putKultura
        /// </summary>
        ///
        public KulturaDto putKultura(Kultura kultura)
        {
            throw new NotImplementedException();
        }
    }
}
