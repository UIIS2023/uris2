using Dokumenti_Service.Entities.Oglas;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dokumenti_Service.Models
{
    public class OglasnaTablaCreationDTO
    {
        /// <summary>
        /// Broj oglasne table
        /// </summary>
        public int BrojOglasneTable { get; set; }
        /// <summary>
        /// Lista aktivnih oglasa
        /// </summary>
      
        public List<Oglas> oglasi { get; set; }


        /// <summary>
        /// Datum objavljivanja oglasne table
        /// </summary>
        public DateTime? DatumObjavljivanja { get; set; }
    }
}
