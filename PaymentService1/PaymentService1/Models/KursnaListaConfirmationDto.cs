namespace PaymentService1.Models
{
    /// <summary>
    /// Dto o potvrdi kursne liste
    /// </summary>
    public class KursnaListaConfirmationDto
    {
        /// <summary>
        /// Id kursne liste
        /// </summary>
        public Guid KursnaListaID { get; set; }
        /// <summary>
        /// Valuta
        /// </summary>
        public string? valuta { get; set; }
    }
}
