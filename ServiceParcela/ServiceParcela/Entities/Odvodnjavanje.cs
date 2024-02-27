using System.ComponentModel.DataAnnotations;

namespace ServiceParcela.Entities
{
    /// <summary>
    /// Odvodnjavanje
    /// </summary>
    /// 
    public class Odvodnjavanje
    {
        /// <summary>
        /// Id odvodnjavanja
        /// </summary>
        /// 
        [Key]
        public Guid odvodnjavanjeID { get; set; }

        /// <summary>
        /// Naziv odvodnjavanja
        /// </summary>
        /// 
        public string? nazivOdvodnjavanja { get; set; }
    }
}
