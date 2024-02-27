namespace ServiceParcela.DtoModels
{
    /// <summary>
    /// ParcelaDto
    /// </summary>
    /// 
    public class ParcelaDto
    {
        /// <summary>
        /// Id parcele
        /// </summary>
        /// 
        public Guid parcelaID { get; set; }
        /// <summary>
        /// Id korisnika parcele
        /// </summary>
        /// 
        public Guid korisnikParceleID { get; set; }
        /// <summary>
        /// Povrsina parcele
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
        public Guid kulturaID { get; set; }
        /// <summary>
        /// Id klase
        /// </summary>
        /// 
        public Guid klasaID { get; set; }
        /// <summary>
        /// Id obradivosti
        /// </summary>
        /// 
        public Guid obradivostID { get; set; }
        /// <summary>
        /// Id zasticene zone
        /// </summary>
        /// 
        public Guid zasticenaZonaID { get; set; }
        /// <summary>
        /// Id oblika svojine
        /// </summary>
        /// 
        public Guid oblikSvojineID { get; set; }
        /// <summary>
        /// Id odvodnjavanja
        /// </summary>
        /// 
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
    }
}
