using System.ComponentModel.DataAnnotations;

namespace Dokumenti_Service.Entities.Dokument
{
    public class Status
    {
        /// <summary>
        /// DokumentStatusID - ID statusa dokumenta
        /// Example: 07af89f2-feee-4680-b489-9d0e31699588
        /// </summary>
        [Key]
        public Guid statusID { get; set; }

        /// <summary>
        /// Status - Status dokumenta
        /// Example:Usvojen
        /// </summary>
        public string status { get; set; }
    }
}
