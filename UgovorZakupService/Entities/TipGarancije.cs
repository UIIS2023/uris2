using System.ComponentModel.DataAnnotations;

namespace UgovorZakupService.Entities
{
    public class TipGarancije
    {
        [Key]
        public Guid tipGarancijeID { get; set; }
        public string? nazivTipaGarancije { get; set; }
    }
}