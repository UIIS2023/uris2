namespace CustomerService1.Models
{
    /// <summary>
    /// DTO za kontakt osobu
    /// </summary>
    public class KontaktOsobaDto
    {
        /// <summary>
        /// Id kontakt osobe
        /// </summary>
        public Guid KontaktOsobaID { get; set; }
        /// <summary>
        /// Ima kontakt osobe
        /// </summary>
        public string? Ime { get; set; }
        /// <summary>
        /// Prezime kontakt osobe
        /// </summary>
        public string? Prezime { get; set; }
        
    }
}
