using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServiceParcela.Entities
{
    /// <summary>
    ///  Deo parcele
    /// </summary>
    /// 
    public class DeoParcele
    {
        /// <summary>
        /// Id dela parcele
        /// </summary>
        /// 
        [Key]
        public Guid deoParceleID { get; set; }

        /// <summary>
        /// Id parcele
        /// </summary>
        /// 
        [ForeignKey("Parcela")]
        public Guid parcelaID { get; set; }

        /// <summary>
        /// Idealni deo parcele
        /// </summary>
        /// 
        [Required]
        public int idealniDeoParcele { get; set; }

        /// <summary>
        /// Stavrni deo parcele
        /// </summary>
        /// 
        public int stvarniDeoParcele { get; set; }
    }
}
