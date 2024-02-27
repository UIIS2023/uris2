namespace PaymentService1.Models
{
    /// <summary>
    /// Dto kurne liste
    /// </summary>
    public class KursnaListaDto
    {
        /// <summary>
        /// Id kursne liste
        /// </summary>
        public Guid KursnaListaID { get; set; }
        /// <summary>
        /// Valuta
        /// </summary>
        public string valuta { get; set; }
    }
}
