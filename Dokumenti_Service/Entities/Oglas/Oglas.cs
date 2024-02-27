using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dokumenti_Service.Entities.Oglas
{
    public class Oglas
    {

        /// <summary>
        /// ID oglas
        /// </summary>
        [Key]
        public Guid oglasId { get; set; }

        /// <summary>
        /// Tekst oglasa
        /// </summary>
        public string tekstOglasa { get; set; }

        /// <summary>
        /// ID OGLASNE TABLE
        /// </summary>
        [ForeignKey("OglasnaTabla")]
        public Guid oglasnaTablaId { get; set; }

        public  OglasnaTabla oglasnaTabla { get; set; }
        public Guid? dokumentId { get; set; }
        public Dokument.Dokument dokument { get; set; }
    }
}
