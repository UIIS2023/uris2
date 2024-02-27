using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dokumenti_Service.Entities.Oglas
{
    public class OglasnaTabla
    {
        /// <summary>
        /// ID sluzbeni list 
        /// </summary>
        [Key]
        public Guid oglasnaTablaId { get; set; }

        /// <summary>
        /// Broj oglasne table
        /// </summary>
        public int BrojOglasneTable { get; set; }
        /// <summary>
        /// Lista aktivnih oglasa
        /// </summary>
         [NotMapped]
        public List<Guid> oglasi { get; set; }
       

        /// <summary>
        /// Datum objavljivanja oglasne table
        /// </summary>
        public DateTime? DatumObjavljivanja { get; set; }

    }
}
