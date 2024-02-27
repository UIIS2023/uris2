using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dokumenti_Service.Entities.Dokument
{
    public class Dokument
    {
        /// <summary>
        /// ID dokumenta
        /// Example:07af89f2-feee-4680-b489-9d0e31699588
        /// </summary>
        [Key]
        public Guid dokumentId { get; set; }

        /// <summary>
        /// zavodniBroj - broj registracije 
        /// Exaple: 1123232323
        /// </summary>
        public string zavodniBroj { get; set; }

        /// <summary>
        /// datumKreiranjaDokumenta - Datum krairanja dokumenta
        /// </summary>
        public DateTime? datumKreiranjaDokumenta { get; set; }

        /// <summary>
        /// DatumDokumenta - Datum u dokumenta 
        /// </summary>
        public DateTime? datumDokumenta { get; set; }

        /// <summary>
        /// sablon - Šablon dokumenta
        /// </summary>
        public string sablon { get; set; }

        /// <summary>
        /// statusDokumenta - Status dokumenta 
        /// </summary>
        [ForeignKey("Status")]
        public Guid dokumentStatusID{ get; set; }
        [NotMapped]
        public Status statusDokumenta { get; set; }

    }
}
