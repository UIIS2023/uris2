using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UgovorZakupService.Entities;

namespace UgovorZakupService.DtoModels
{
    public class UgovorOZakupuDto
    {
        [Key]
        public Guid ugovorOZakupuID { get; set; }

        public Guid javnoNadmetanjeID { get; set; }
        public JavnoNadmetanjeDto? javnoNadmetanje { get; set; }

        public Guid dokumentID { get; set; }
        public DokumentDto? odluka { get; set; }

        public Guid tipGarancijeID { get; set; }
        public TipGarancije? tipGarancije { get; set; }

        public Guid kupacID { get; set; }
        public KupacDto? lice { get; set; }

        public int[]? rokoviDospeca { get; set; }
        public string? zavodniBroj { get; set; }
        public DateTime datumZavodjenja { get; set; }

        public Guid licnostID { get; set; }
        public LicnostDto? ministar { get; set; }

        public DateTime rokVracanjeZemljista { get; set; }
        public string? mestoPotpisivanja { get; set; }
        public DateTime datumPotpisa { get; set; }
    }
}
