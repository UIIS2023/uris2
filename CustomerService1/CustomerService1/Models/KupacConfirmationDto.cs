namespace CustomerService1.Models
{
    /// <summary>
    /// DTO za potvrdu kupca
    /// </summary>
    public class KupacConfirmationDto
    {
        /// <summary>
        /// Id kupca
        /// </summary>
        public Guid KupacID { get; set; }
        /// <summary>
        /// Da li je kupac fizicko ili pravno lice
        /// </summary>
        public bool FizPravno { get; set; }
        /// <summary>
        /// Ostvarena povrsina kupca
        /// </summary>
        public string? OstvarenaPovrsina { get; set; }
        /// <summary>
        /// Broj telefona kupca
        /// </summary>
        public string? BrTel1 { get; set; }
        /// <summary>
        /// Email kupca
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Broj racuna kupca
        /// </summary>
        public string? BrojRacuna { get; set; }

        
    }
}
