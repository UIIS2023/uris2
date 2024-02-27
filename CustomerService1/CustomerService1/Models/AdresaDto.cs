namespace CustomerService1.Models
{
    /// <summary>
    /// Dto za adresu
    /// </summary>
    public class AdresaDto
    {
        /// <summary>
        /// Id adrese
        /// </summary>
        /// 

        public Guid adresaId { get; set; }
        /// <summary>
        /// Ulica
        /// </summary>
        /// 
        public string? ulica { get; set; }
        /// <summary>
        /// Broj ulice
        /// </summary>
        /// 
        public string? broj { get; set; }
        /// <summary>
        /// Mesto
        /// </summary>
        /// 
        public string? mesto { get; set; }
        /// <summary>
        /// Postanski broj
        /// </summary>
        /// 
        public string? postanskiBroj { get; set; }
        /// <summary>
        /// Drzava
        /// </summary>
        /// 
        public string? Drzava { get; set; }

    }
}
