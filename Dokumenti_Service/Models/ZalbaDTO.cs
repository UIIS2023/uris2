using Dokumenti_Service.Entities.Dokument;
using Dokumenti_Service.Entities.Zalba;

namespace Dokumenti_Service.Models
{
    public class ZalbaDTO
    {
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
        public Guid tipZalbeId { get; set; }
        
        

        /// <summary>
        /// Status zalbe
        /// </summary>
        public string statusZalbe { get; set; }
        /// <summary>
        /// ID dogadjaja na osnovu zalbe
        /// </summary>
        public Guid radnjaNaOsnovuZalbeID { get; set; }
        
        
        /// <summary>
        /// Id kupca
        /// </summary>
        public Guid? KupacID { get; set; }
        public Guid? dokumentId { get; set; }
        
    }
}
