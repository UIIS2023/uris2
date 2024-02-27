namespace CustomerService1.Entities
{
    public class PravnoLice
    {
        /// <summary>
        /// Naziv pravnog lica
        /// </summary>
        public string Naziv { get; set; }
        /// <summary>
        /// Maticni broj
        /// </summary>
        public string MatBr { get; set; }
        /// <summary>
        /// Faks
        /// </summary>
        public string Faks { get; set; }
        /// <summary>
        /// Id kontakt osobe
        /// </summary>
        public Guid KontaktOsobaID { get; set; }
    }
}
