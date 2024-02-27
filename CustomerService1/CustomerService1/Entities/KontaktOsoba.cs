namespace CustomerService1.Entities
{
    public class KontaktOsoba
    {
        /// <summary>
        /// Id kontakt osobe
        /// </summary>
        public Guid KontaktOsobaID { get; set; }
        /// <summary>
        /// Ime
        /// </summary>
        public string Ime { get; set; }
        /// <summary>
        /// Prezime
        /// </summary>
        public string Prezime { get; set; }
        /// <summary>
        /// Funkcija
        /// </summary>
        public string Funkcija { get; set; }
        /// <summary>
        /// Broj telefona
        /// </summary>
        public string Telefon { get; set; }
    }
}
