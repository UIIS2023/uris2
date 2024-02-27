namespace CustomerService1.Models
{
    /// <summary>
    /// Dto za ovlasceno lice
    /// </summary>
    public class OvlascenoLiceDto
    {
        /// <summary>
        /// Id ovlascenog lica
        /// </summary>
        /// 

        public Guid ovlascenoLiceId { get; set; }
        /// <summary>
        /// Ime ovlascenog lica
        /// </summary>
        /// 
        public string? ime { get; set; }
        /// <summary>
        /// Prezime ovlascenog lica
        /// </summary>
        /// 
		public string? prezime { get; set; }
        /// <summary>
        /// Lista lica za koje se vrsi licitacija
        /// </summary>
        /// 
		public List<Guid>? licaZaKojaVrsiLicitaciju { get; set; }
        /// <summary>
        /// Lista broja tabli
        /// </summary>
        /// 
		public List<int>? brojTabli { get; set; }
    }
}

