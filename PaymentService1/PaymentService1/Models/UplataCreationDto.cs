namespace PaymentService1.Models
{
    /// <summary>
    /// Dto za kreiranje uplate
    /// </summary>
    public class UplataCreationDto
    {
        /// <summary>
        /// Broj racuna
        /// </summary>
        public string brojRacuna { get; set; }
        /// <summary>
        /// Poziv na broj
        /// </summary>
        public string pozivNaBroj { get; set; }
        /// <summary>
        /// Iznos uplate
        /// </summary>
        public float iznos { get; set; }
        /// <summary>
        /// Uplatilac
        /// </summary>
        public Guid uplatilac { get; set; }
        /// <summary>
        /// Svrha uplate
        /// </summary>
        public string svrhaUplate { get; set; }
        /// <summary>
        /// Datum uplate
        /// </summary>
        public DateTime datum { get; set; }
        /// <summary>
        /// Javno nadmetanje
        /// </summary>
        public Guid javnoNadmetanje { get; set; }
    }
}
