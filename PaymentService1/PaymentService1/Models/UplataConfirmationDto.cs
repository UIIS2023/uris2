namespace PaymentService1.Models
{
    /// <summary>
    /// Dto potvrde uplate
    /// </summary>
    public class UplataConfirmationDto
    {
        /// <summary>
        /// Id uplate
        /// </summary>
        public Guid UplataID { get; set; }
        /// <summary>
        /// Broj racuna uplate
        /// </summary>
        public string brojRacuna { get; set; }
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
