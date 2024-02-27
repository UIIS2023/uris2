namespace ServiceParcela.DtoModels
{
    /// <summary>
    /// PravnoLiceDto
    /// </summary>
    /// 
    public class PravnoLiceDto
    {
        /// <summary>
        /// Id lica
        /// </summary>
        /// 
        public Guid liceID { get; set; }
        /// <summary>
        /// Naziv pravnog lica
        /// </summary>
        /// 
        public string? naziv { get; set; }
        /// <summary>
        /// Maticni broj pravnog lica
        /// </summary>
        /// 
        public string? maticniBroj { get; set; }
        /// <summary>
        /// AdresaDto
        /// </summary>
        /// 
        public AdresaDto? adresa { get; set; }
        /// <summary>
        /// Prvi broj telefona
        /// </summary>
        /// 
        public string? brojTelefona1 { get; set; }
        /// <summary>
        /// Drugi broj telefona
        /// </summary>
        /// 
        public string? brojTelefona2 { get; set; }
        /// <summary>
        /// Faks pravnog lica
        /// </summary>
        /// 
        public string? faks { get; set; }
        /// <summary>
        /// Email pravnog lica
        /// </summary>
        /// 
        public string? email { get; set; }
        /// <summary>
        /// Broj racuna pravnog lica
        /// </summary>
        /// 
        public string? brojRacuna { get; set; }
    }
}
