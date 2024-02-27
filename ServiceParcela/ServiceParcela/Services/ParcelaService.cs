using AutoMapper;
using ServiceParcela.DtoModels;
using ServiceParcela.Entities;
using ServiceParcela.Repositories;

namespace ServiceParcela.Services
{
    /// <summary>
    /// ParcelaService
    /// </summary>
    ///
    public class ParcelaService : IParcelaRepository
    {
        /// <summary>
        /// ParcelaService
        /// </summary>
        ///
        public static List<Parcela> parcelas { get; set; } = new List<Parcela>();
        private readonly IMapper mapper;
        private readonly ParcelaContex context;
        /// <summary>
        /// ParcelaService
        /// </summary>
        ///
        public ParcelaService(IMapper mapper, ParcelaContex context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        /// <summary>
        /// deleteParcela
        /// </summary>
        ///
        public void deleteParcela(Guid id)
        {
            Parcela parcela = getParcelaByID(id);
            context.parcele.Remove(parcela);
        }
        /// <summary>
        /// getAllParcela
        /// </summary>
        ///
        public List<Parcela> getAllParcela()
        {
            return context.parcele.ToList();
        }
        /// <summary>
        /// getParcelaByID
        /// </summary>
        ///
        public Parcela getParcelaByID(Guid id)
        {
            return context.parcele.FirstOrDefault(parcela => parcela.parcelaID == id);
        }
        /// <summary>
        /// postParcela
        /// </summary>
        ///
        public ParcelaDto postParcela(Parcela parcela)
        {
            parcela.parcelaID = Guid.NewGuid();
            context.parcele.Add(parcela);
            return mapper.Map<ParcelaDto>(parcela);
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
        /// putParcela
        /// </summary>
        ///
        public ParcelaDto putParcela(Parcela parcela)
        {
            throw new NotImplementedException();
        }
    }
}
