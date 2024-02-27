namespace ServiceParcela.DtoModels
{
    /// <summary>
    /// AdresaDto
    /// </summary>
    /// 
    public class AdresaDto
    {
        /// <summary>
        /// Id adrese
        /// </summary>
        /// 
        public Guid adresaID { get; set; }
        /// <summary>
        /// Naziv ulice
        /// </summary>
        /// 
        public string? ulica { get; set; }
        /// <summary>
        /// Naziv mesta
        /// </summary>
        /// 
        public string? mesto { get; set; }
        /// <summary>
        /// Postanski broj
        /// </summary>
        /// 
        public string? postanskiBroj { get; set; }
    }
}
