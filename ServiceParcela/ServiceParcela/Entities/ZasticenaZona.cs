using System.ComponentModel.DataAnnotations;

namespace ServiceParcela.Entities
{
    /// <summary>
    /// Zasticena zona
    /// </summary>
    /// 
    public class ZasticenaZona
    {
        /// <summary>
        /// Id zasticene zone
        /// </summary>
        /// 
        [Key]
        public Guid zasticenaZonaID { get; set; }

        /// <summary>
        /// Naziv zasticene zone
        /// </summary>
        /// 
        public string? nazivZasticeneZone { get; set; }
    }
}
