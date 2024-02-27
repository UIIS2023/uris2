using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UgovorZakupService.DtoModels;

namespace UgovorZakupService.Entities
{
    public class UgovorOZakupu
    {
        [Key]
        public Guid ugovorOZakupuID { get; set; }

        [ForeignKey("JavnoNadmetanje")]
        public Guid javnoNadmetanjeID { get; set; }
        [NotMapped]
        public JavnoNadmetanjeDto? javnoNadmetanje { get; set; }

        [ForeignKey("Dokument")]
        public Guid dokumentID { get; set; }
        [NotMapped]
        public DokumentDto? odluka { get; set; }

        [ForeignKey("TipGarancije")]
        public Guid tipGarancijeID { get; set; }
        [NotMapped]
        public TipGarancije? tipGarancije { get; set; }

        [ForeignKey("Kupac")]
        public Guid kupacID { get; set; }
        [NotMapped]
        public KupacDto? lice { get; set; }

        [NotMapped]
        public int[]? rokoviDospeca { get; set; }
        public string? zavodniBroj { get; set; }
        public DateTime datumZavodjenja { get; set; }

        [ForeignKey("Licnost")]
        public Guid licnostID { get; set; }
        [NotMapped]
        public LicnostDto? ministar { get; set; }

        public DateTime rokVracanjeZemljista { get; set; }
        public string? mestoPotpisivanja { get; set; }
        public DateTime datumPotpisa { get; set; }
    }
}
