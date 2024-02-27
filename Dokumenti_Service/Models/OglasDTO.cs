using Dokumenti_Service.Entities.Dokument;
using Dokumenti_Service.Entities.Oglas;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dokumenti_Service.Models
{
    public class OglasDTO
    {
        public Guid oglasId { get; set; }


        public string tekstOglasa { get; set; }


        public Guid oglasnaTablaId { get; set; }
       
        public Guid dokumentId { get; set; }
        
    }
}
