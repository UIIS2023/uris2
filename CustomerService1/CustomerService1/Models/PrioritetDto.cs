namespace CustomerService1.Models
{
    /// <summary>
    /// DTO za prioritet
    /// </summary>
    public class PrioritetDto
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
