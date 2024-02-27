namespace CustomerService1.Models
{
    /// <summary>
    /// DTO za potvrdu prioriteta
    /// </summary>
    public class PrioritetConfirmationDto
    {
        /// <summary>
        /// Id prioriteta
        /// </summary>
        public Guid PrioritetID { get; set; }
        /// <summary>
        /// Opis prioriteta
        /// </summary>
        public string? OpisPrioriteta { get; set; }
    }
}
