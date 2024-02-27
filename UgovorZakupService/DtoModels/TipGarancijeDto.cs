using System.ComponentModel.DataAnnotations;

namespace UgovorZakupService.DtoModels
{
    public class TipGarancijeDto
    {
        [Key]
        public Guid tipGarancijeID { get; set; }
        public string? nazivTipaGarancije { get; set; }
    }
}
