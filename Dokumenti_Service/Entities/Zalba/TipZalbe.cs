using System.ComponentModel.DataAnnotations;

namespace Dokumenti_Service.Entities.Zalba
{
    public class TipZalbe
    {
        /// <summary>
        /// Predstavlja ID tipa zalbe
        /// </summary>
        [Key]
        public Guid tipZalbeId { get; set; }
        /// <summary>
        /// Tip zalbe
        /// </summary>
        public string tipZalbe { get; set; }
    }
}
