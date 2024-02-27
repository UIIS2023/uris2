namespace CustomerService1.Entities
{
    public class KontaktOsobaConfirmation
    {
        /// <summary>
        /// Id kontakt osobe
        /// </summary>
        public Guid KontaktOsobaID { get; set; }
        /// <summary>
        /// Ime kontakt osobe
        /// </summary>
        public string Ime { get; set; }
        /// <summary>
        /// Prezime kontakt osobe
        /// </summary>
        public string Prezime { get; set; }
    }
}
