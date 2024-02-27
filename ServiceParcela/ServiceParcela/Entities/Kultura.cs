using System.ComponentModel.DataAnnotations;

namespace ServiceParcela.Entities
{
    /// <summary>
    /// Kultura
    /// </summary>
    /// 
    public class Kultura
    {
        /// <summary>
        /// Id kulture
        /// </summary>
        /// 
        [Key]
        public Guid kulturaID { get; set; }

        /// <summary>
        /// Naziv kulture
        /// </summary>
        /// 
        public string? nazivKulture { get; set; }
    }
}
