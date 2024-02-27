using Dokumenti_Service.Entities.Oglas;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dokumenti_Service.Models
{
    public class OglasnaTablaDTO
    {
        public Guid oglasnaTablaId { get; set; }

        /// <summary>
        /// Broj oglasne table
        /// </summary>
        public int BrojOglasneTable { get; set; }
        /// <summary>
        /// Lista aktivnih oglasa
        /// </summary>
        
        public List<Guid> oglasi { get; set; }


        /// <summary>
        /// Datum objavljivanja oglasne table
        /// </summary>
        public DateTime? DatumObjavljivanja { get; set; }
    }
}
