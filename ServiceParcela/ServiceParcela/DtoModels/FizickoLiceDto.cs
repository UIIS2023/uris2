namespace ServiceParcela.DtoModels
{
    /// <summary>
    /// FizickoLiceDto
    /// </summary>
    /// 
    public class FizickoLiceDto
    {
        /// <summary>
        /// Id lica
        /// </summary>
        /// 
        public Guid liceID { get; set; }
        /// <summary>
        /// Naziv fizickog lica
        /// </summary>
        /// 
        public string? naziv { get; set; }
        /// <summary>
        /// Maticni broj fizickog lica
        /// </summary>
        /// 
        public string? maticniBroj { get; set; }
        /// <summary>
        /// Adresa fizickog lica
        /// </summary>
        /// 
        public AdresaDto? adresa { get; set; }
        /// <summary>
        /// Prvi broj telfona fl
        /// </summary>
        /// 
        public string? brojTelefona1 { get; set; }
        /// <summary>
        /// Drugi broj telefona fl
        /// </summary>
        /// 
        public string? brojTelefona2 { get; set; }
        /// <summary>
        /// Faks fizickog lica
        /// </summary>
        /// 
        public string? faks { get; set; }
        /// <summary>
        /// Email fizickog lica
        /// </summary>
        /// 
        public string? email { get; set; }

    }
}
