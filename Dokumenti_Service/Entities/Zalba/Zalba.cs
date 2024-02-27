using System.ComponentModel.DataAnnotations;

namespace Dokumenti_Service.Entities.Zalba
{
    public class Zalba
    {
        /// <summary>
        /// ID zalbe
        /// </summary>
        [Key]
        public Guid zalbaId { get; set; }
        /// <summary>
        /// Datum podnosenja zalbe
        /// </summary>
        public DateTime datumPodnosenja { get; set; }
        /// <summary>
        /// Razlog zalbe
        /// </summary>
        public string razlog { get; set; }
        /// <summary>
        /// Obrazlozenje
        /// </summary>
        public string obrazlozenje { get; set; }
        /// <summary>
        /// Broj odluke
        /// </summary>
        public string brojOdluke { get; set; }
        /// <summary>
        /// Broj resenja
        /// </summary>
        public string brojResenja { get; set; }
        /// <summary>
        /// ID tipa zalbe
        /// </summary>
        public Guid tipZalbeID { get; set; }
        /// <summary>
        /// Tip zalbe
        /// </summary>
        public TipZalbe tipZalbe { get; set; }
        
        /// <summary>
        /// Status zalbe
        /// </summary>
        public string statusZalbe { get; set; }
        /// <summary>
        /// ID dogadjaja na osnovu zalbe
        /// </summary>
        public Guid radnjaNaOsnovuZalbeId { get; set; }
        /// <summary>
        /// Dogadjaj na osnovu zalbe
        /// </summary>
        public RadnjaNaOsnovuZalbe radnjaNaOsnovuZalbe { get; set; }
        
        /// <summary>
        /// Id kupca
        /// </summary>
        public Guid? KupacID { get; set; }
        public Guid? dokumentId { get; set; }
        public Dokument.Dokument dokument { get; set; }

    }
}
