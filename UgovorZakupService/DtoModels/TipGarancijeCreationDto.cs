using System.ComponentModel.DataAnnotations;

namespace UgovorZakupService.DtoModels
{
    public class TipGarancijeCreationDto
    {
        [Required(ErrorMessage = "Requires field")]
        public string? nazivTipaGarancije { get; set; }
    }
}
