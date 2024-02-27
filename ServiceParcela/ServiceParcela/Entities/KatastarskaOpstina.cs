using System.ComponentModel.DataAnnotations;

namespace ServiceParcela.Entities
{
    /// <summary>
    /// Katastarska osptina
    /// </summary>
    /// 
    public class KatastarskaOpstina
    {
        /// <summary>
        /// Id katastarske opstine
        /// </summary>
        /// 
        [Key]
        public Guid katastarskaOpstinaID { get; set; }

        /// <summary>
        /// Naziv katastarske opstine
        /// </summary>
        /// 
        public string? nazivKatastarskeOpstine { get; set; }
    }
}
