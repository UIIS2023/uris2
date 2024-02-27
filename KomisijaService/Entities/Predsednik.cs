using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomisijaService.Entities
{
    public class Predsednik
    {
        [Key]
        public Guid predsednikID { get; set; }

        public override string ToString()
        {
            return "Predsednik: { PredsednikId: " + this.predsednikID + " }";
        }
    }
}
