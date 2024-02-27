using System.ComponentModel.DataAnnotations.Schema;

namespace Dokumenti_Service.Entities.Oglas
{
    public class OglasnaTablaOglas
    {
        [ForeignKey("OglasnaTabla")]
        public Guid oglasnaTablaId { get; set; }
        [ForeignKey("Oglas")]
        public Guid oglasId { get; set; }

        public Oglas Oglas { get; set; }
        public OglasnaTabla OglasnaTabla { get; set; }
    }
}
