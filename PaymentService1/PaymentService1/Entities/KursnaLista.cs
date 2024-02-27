namespace PaymentService1.Entities
{
    public class KursnaLista
    {
        /// <summary>
        /// Id kursne liste
        /// </summary>
        public Guid KursnaListaID { get; set; }
        /// <summary>
        /// Datum
        /// </summary>
        public DateTime datum { get; set; }
        /// <summary>
        /// Valuta
        /// </summary>
        public string? valuta { get; set; }
        /// <summary>
        /// Vrednost valute
        /// </summary>
        public float vrednost { get; set; }
    }
}
