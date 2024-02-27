using AutoMapper;
using ServiceParcela.DtoModels;
using ServiceParcela.Entities;
using ServiceParcela.Repositories;
using System.Xml.Linq;

namespace ServiceParcela.Services
{
    /// <summary>
    /// KatastarskaOpstinaService
    /// </summary>
    ///
    public class KatastarskaOpstinaService : IKatastarskaOpstinaRepository
    {
        /// <summary>
        /// KatastarskaOpstinaService
        /// </summary>
        ///
        public static List<KatastarskaOpstina> katastarskaOpstinas { get; set; } = new List<KatastarskaOpstina>();

        private readonly IMapper mapper;
        private readonly ParcelaContex context;

        /// <summary>
        /// KatastarskaOpstinaService
        /// </summary>
        ///
        public KatastarskaOpstinaService(IMapper mapper, ParcelaContex context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        /// <summary>
        /// deleteKatastarskaOpstina
        /// </summary>
        ///
        public void deleteKatastarskaOpstina(Guid id)
        {
            Entities.KatastarskaOpstina katastarskaOpstina = getKatastarskaOpstinaByID(id);
            context.katastarskeOpstine.Remove(katastarskaOpstina);
        }
        /// <summary>
        /// getAllKatastarskaOpstina
        /// </summary>
        ///
        public List<KatastarskaOpstina> getAllKatastarskaOpstina()
        {
            return context.katastarskeOpstine.ToList();
        }
        /// <summary>
        /// getKatastarskaOpstinaByID
        /// </summary>
        ///
        public KatastarskaOpstina getKatastarskaOpstinaByID(Guid id)
        {
            return context.katastarskeOpstine.FirstOrDefault(katastarskaOpstina => katastarskaOpstina.katastarskaOpstinaID == id);

        }
        /// <summary>
        /// postKatastarskaOpstina
        /// </summary>
        ///
        public KatastarskaOpstinaDto postKatastarskaOpstina(KatastarskaOpstina katastarskaOpstina)
        {
            katastarskaOpstina.katastarskaOpstinaID = Guid.NewGuid();
            context.katastarskeOpstine.Add(katastarskaOpstina);
            return mapper.Map<KatastarskaOpstinaDto>(katastarskaOpstina);
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
        /// putKatastarskaOpstina
        /// </summary>
        ///
        public KatastarskaOpstinaDto putKatastarskaOpstina(KatastarskaOpstina katastarskaOpstina)
        {
            throw new NotImplementedException();
        }
    }
}
