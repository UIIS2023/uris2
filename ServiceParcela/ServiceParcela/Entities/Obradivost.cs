using System.ComponentModel.DataAnnotations;

namespace ServiceParcela.Entities
{
    /// <summary>
    /// Obradivost
    /// </summary>
    /// 
    public class Obradivost
    {
        /// <summary>
        /// Id obradivosti
        /// </summary>
        /// 
        [Key]
        public Guid obradivostID { get; set; }

        /// <summary>
        /// Naziv obradivosti
        /// </summary>
        /// 
        public string? nazivObradivosti { get; set; }
    }
}
