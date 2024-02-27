using UgovorZakupService.Entities;

namespace UgovorZakupService.DtoModels
{
    public class UgovorOZakupuCreationDto
    {
        public Guid javnoNadmetanjeID { get; set; }

        public Guid dokumentID { get; set; }

        public Guid tipGarancijeID { get; set; }

        public Guid kupacID { get; set; }

        public int[]? rokoviDospeca { get; set; }
        public string? zavodniBroj { get; set; }
        public DateTime datumZavodjenja { get; set; }

        public Guid licnostID { get; set; }

        public DateTime rokVracanjeZemljista { get; set; }
        public string? mestoPotpisivanja { get; set; }
        public DateTime datumPotpisa { get; set; }
    }
}
