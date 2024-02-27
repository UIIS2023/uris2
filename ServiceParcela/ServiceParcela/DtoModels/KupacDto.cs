namespace ServiceParcela.DtoModels
{
    /// <summary>
    /// KupacDto
    /// </summary>
    /// 
    public class KupacDto
    {
        /// <summary>
        /// Id kupca
        /// </summary>
        /// 
        public Guid kupacID { get; set; }

        /// <summary>
        /// Fizicko ili pravno lice
        /// </summary>
        /// 
        public bool fizickoPravnoLice { get; set; }

        /// <summary>
        /// Ostvarena povrsina
        /// </summary>
        /// 
        public string? osvarenaPovrsina { get; set; }

        /// <summary>
        /// Postojanje zabrane kupca
        /// </summary>
        /// 
		public bool zabrana { get; set; }

        /// <summary>
        /// Datum pocetka zabrane
        /// </summary>
        /// 
		public DateTime pocetakZabrane { get; set; }

        /// <summary>
        /// Trajanje zabrane
        /// </summary>
        /// 
        public int duzinaZabrane { get; set; }

        /// <summary>
        /// Datum prestanka zabrane
        /// </summary>
        /// 
		public DateTime prestanakZabrane { get; set; }

        /// <summary>
        /// Id ovlascenog lica
        /// </summary>
        /// 
		public Guid? ovlascenoLiceId { get; set; }

        /// <summary>
        /// Id prioriteta
        /// </summary>
        /// 
		public Guid prioritetId { get; set; }

        /// <summary>
        /// Naziv lica
        /// </summary>
        /// 
        public string? lice { get; set; }

        /// <summary>
        /// Prvi broj telefona kupca
        /// </summary>
        /// 
		public string? brTel1 { get; set; }

        /// <summary>
        /// Drugi broj telefona kupca
        /// </summary>
        /// 
        public string? brTel2 { get; set; }

        /// <summary>
        /// Id adrese
        /// </summary>
        /// 
		public Guid adresaId { get; set; }

        /// <summary>
        /// Id uplate
        /// </summary>
        /// 
		public string? uplataId { get; set; }

        /// <summary>
        /// Email kupca
        /// </summary>
        /// 
		public string? email { get; set; }

        /// <summary>
        /// Broj racuna kupca
        /// </summary>
        /// 
		public string? brRacuna { get; set; }
    }
}
