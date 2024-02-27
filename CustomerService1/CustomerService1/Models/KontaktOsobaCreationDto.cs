namespace CustomerService1.Models
{
    /// <summary>
    /// DTO za kreiranje kontakt osobe
    /// </summary>
    public class KontaktOsobaCreationDto
    {
        /// <summary>
        /// Ime kontakt osobe
        /// </summary>
        public string? Ime { get; set; }
        /// <summary>
        /// Prezime kontakt osobe
        /// </summary>
        public string? Prezime { get; set; }
        /// <summary>
        /// Funkcija kontakt osobe
        /// </summary>
        public string? Funkcija { get; set; }
        /// <summary>
        /// Telefon kontakt osobe
        /// </summary>
        public string? Telefon { get; set; }
    }
}
