using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UgovorZakupService.DtoModels
{
    public class JavnoNadmetanjeDto
    {
        [Key]                                     
        public Guid javnoNadmetanjeID { get; set; }
        public DateTime datum { get; set; }
        public DateTime vremePocetka { get; set; }
        public DateTime vremeKraja { get; set; }
        public int pocetnaCenaPoHektaru { get; set; }
        public bool izuzeto { get; set; }
        public int izlicitiranaCena { get; set; }
        public int periodZakupa { get; set; }
        public int brojUcesnika { get; set; }
        public int visinaDopuneDepozita { get; set; }
        public int krug { get; set; }        
        public Guid statusNadmetanjaID { get; set; }                                   
        public Guid tipID { get; set; }                                             
        public Guid ovlascenoLiceID { get; set; }
        [NotMapped]
        public List<Guid>? prijavljeniKupciID { get; set; }
        public Guid adresaID { get; set; }                              
        public Guid najboljiPonudjacID { get; set; }                       
        [NotMapped]
        public List<Guid>? parceleID { get; set; }
    }
}
