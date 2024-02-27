using ServiceParcela.DtoModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServiceParcela.Entities
{
    /// <summary>
    /// Parcela
    /// </summary>
    /// 
    public class Parcela
    {
        /// <summary>
        /// Id parcele
        /// </summary>
        /// 
        [Key]
        public Guid parcelaID { get; set; }

        /// <summary>
        /// Id korisnika parcele
        /// </summary>
        /// 
        public Guid korisnikParceleID { get; set; }

        /// <summary>
        /// Povrsina
        /// </summary>
        /// 
        public int povrsina { get; set; }

        /// <summary>
        /// Broj parcele
        /// </summary>
        /// 
        public string? brojParcele { get; set; }

        /// <summary>
        /// Id katastarske opstine
        /// </summary>
        /// 
        public Guid katastarskaOpstinaID { get; set; }

        /// <summary>
        /// Broj lista nepokretnosti
        /// </summary>
        /// 
        public string? brojListaNepokretnosti { get; set; }

        /// <summary>
        /// Id kulture
        /// </summary>
        /// 
        [ForeignKey("kultura")]
        public Guid kulturaID { get; set; }

        /// <summary>
        /// Id klase
        /// </summary>
        /// 
        [ForeignKey("klasa")]
        public Guid klasaID { get; set; }

        /// <summary>
        /// Id obradivosti
        /// </summary>
        /// 
        [ForeignKey("obradivost")]
        public Guid obradivostID { get; set; }

        /// <summary>
        /// Id zasticene zone
        /// </summary>
        /// 
        [ForeignKey("zasticenaZona")]
        public Guid zasticenaZonaID { get; set; }

        /// <summary>
        /// Id oblika svojine
        /// </summary>
        /// 
        [ForeignKey("oblikSvojine")]
        public Guid oblikSvojineID { get; set; }

        /// <summary>
        /// Id odvodnjavanja
        /// </summary>
        /// 
        [ForeignKey("odvodnjavanje")]
        public Guid odvodnjavanjeID { get; set; }
        /// <summary>
        /// Stvarno stanje obradivosti
        /// </summary>
        /// 
        public string? obradivostStvarnoStanje { get; set; }
        /// <summary>
        /// Stvarno stanje kulture
        /// </summary>
        /// 
        public string? kulturaStvarnoStanje { get; set; }
        /// <summary>
        /// Stvarno stanje klase
        /// </summary>
        /// 
        public string? klasaStvarnoStanje { get; set; }
        /// <summary>
        /// Stvarno stanje zasticene zone
        /// </summary>
        /// 
        public string? zasticenaZonaStvarnoStanje { get; set; }
        /// <summary>
        /// Stvarno stanje odvodnjavanja
        /// </summary>
        /// 
        public string? odvodnjavanjeStvarnoStanje { get; set; }
        /// <summary>
        /// Lista delova parcele
        /// </summary>
        /// 
        public List<DeoParcele>? ListaDelova;
        /// <summary>
        /// KupacDto
        /// </summary>
        /// 
        [NotMapped]
        public KupacDto? kupac { get; set; }
    }
}
