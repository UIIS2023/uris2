namespace CustomerService1.Models
{
    /// <summary>
    /// DTO za potvrdu kontakt osobe
    /// </summary>
    public class KontaktOsobaConfirmationDto
    {
        /// <summary>
        /// Id kontakt osobe
        /// </summary>
        public Guid KontaktOsobaID { get; set; }
        /// <summary>
        /// Ime kontakt osobe
        /// </summary>
        public string? Ime { get; set; }
        /// <summary>
        /// Prezime kontakt osobe
        /// </summary>
        public string? Prezime { get; set; }
        
    }
}
