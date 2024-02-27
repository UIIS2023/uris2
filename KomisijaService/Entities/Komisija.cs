using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomisijaService.Entities
{
    public class Komisija
    {
        [Key]
        public Guid komisijaID { get; set; }
        [ForeignKey("Predsednik")]
        public Guid predsednikID { get; set; }
        [NotMapped]
        public Predsednik? predsednik { get; set; }

        public override string ToString()
        {
            return "Komisija: { KomisijaId: " + this.komisijaID + ", PredsednikId: " + this.predsednikID + " }";
        }
    }
}
