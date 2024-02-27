using System.ComponentModel.DataAnnotations;

namespace ServiceParcela.Entities
{
    /// <summary>
    /// Klasa
    /// </summary>
    /// 
    public class Klasa
    {
        /// <summary>
        /// Id klase
        /// </summary>
        /// 
        [Key]
        public Guid klasaID { get; set; }

        /// <summary>
        /// Naziv klase
        /// </summary>
        /// 
        public string? nazivKlase { get; set; }
    }
}
