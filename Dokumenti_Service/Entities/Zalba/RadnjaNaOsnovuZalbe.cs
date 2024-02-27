using System.ComponentModel.DataAnnotations;

namespace Dokumenti_Service.Entities.Zalba
{
    public class RadnjaNaOsnovuZalbe
    {
        /// <summary>
        /// ID dogadjaja
        /// </summary>
        [Key]
        public Guid radnjaNaOsnovuZalbeId { get; set; }
        /// <summary>
        /// Doagadjaj na osnovu zalbe
        /// </summary>
        public string radnjaNaOsnovuZalbe { get; set; }
    }
}
