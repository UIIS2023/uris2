namespace PaymentService1.Entities
{
    public class UplataConfirmation
    {
        /// <summary>
        /// Id uplate
        /// </summary>
        public Guid UplataID { get; set; }
        /// <summary>
        /// Broj racuna
        /// </summary>
        public string? brojRacuna { get; set; }
        /// <summary>
        /// Iznos uplate
        /// </summary>
        public float iznos { get; set; }
        /// <summary>
        /// Uplatilac
        /// </summary>
        public Guid uplatilac { get; set; }
        /// <summary>
        /// Datum uplate
        /// </summary>
        public DateTime datum { get; set; }
    }
}
