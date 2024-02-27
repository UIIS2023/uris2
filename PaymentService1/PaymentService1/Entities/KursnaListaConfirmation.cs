namespace PaymentService1.Entities
{
    public class KursnaListaConfirmation
    {
        /// <summary>
        /// Id lursne liste
        /// </summary>
        public Guid KursnaListaID { get; set; }
        /// <summary>
        /// Valuta
        /// </summary>
        public string? valuta { get; set; }
    }
}
