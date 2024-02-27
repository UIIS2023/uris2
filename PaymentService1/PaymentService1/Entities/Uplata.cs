namespace PaymentService1.Entities
{
    public class Uplata
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
        /// Poziv na broj
        /// </summary>
        public string? pozivNaBroj { get; set; }
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
        public string? svrhaUplate { get; set; }
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
