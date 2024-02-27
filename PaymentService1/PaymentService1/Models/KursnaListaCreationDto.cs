namespace PaymentService1.Models
{
    /// <summary>
    /// Dto za kreiranje kursne liste
    /// </summary>
    public class KursnaListaCreationDto
    {
        /// <summary>
        /// Datum
        /// </summary>
        public DateTime datum { get; set; }
        /// <summary>
        /// Valuta
        /// </summary>
        public string valuta { get; set; }
        /// <summary>
        /// Vrednost valute
        /// </summary>
        public float vrednost { get; set; }
    }
}
