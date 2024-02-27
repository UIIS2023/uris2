namespace CustomerService1.Models
{
    /// <summary>
    /// DTO za uplatu
    /// </summary>
    public class UplataDto
    {
        /// <summary>
        /// Id uplate
        /// </summary>
        public Guid UplataID { get; set; }
        /// <summary>
        /// Iznos uplate
        /// </summary>
        public float Iznos { get; set; }
    }
}
