using System.ComponentModel.DataAnnotations;

namespace ServiceParcela.Entities
{
    /// <summary>
    /// Oblik svojine
    /// </summary>
    /// 
    public class OblikSvojine
    {
        /// <summary>
        /// Id oblika svojine
        /// </summary>
        /// 
        [Key]
        public Guid oblikSvojineID { get; set; }

        /// <summary>
        /// Naziv oblika svojine
        /// </summary>
        /// 
        public string? nazivOblikaSvojine { get; set; }
    }
}
