using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KomisijaService.Entities
{
    public class Clanovi
    {
        [Key]
        public Guid clanoviID { get; set; }
        [ForeignKey("Komisija")]
        public Guid? komisijaID { get; set; }
        [NotMapped]
        public Komisija? Komisija { get; set; }

       public override string ToString()
        {
            return "Clanovi: { ClanId: " + this.clanoviID + ", KomisijaId: " + this.komisijaID + " }";
        }
    }
}
