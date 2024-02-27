using System.ComponentModel.DataAnnotations;

namespace UgovorZakupService.DtoModels
{
    public class KupacDto
    {
        [Key]
        public Guid kupacID { get; set; }

        public bool fizickoPravnoLice { get; set; }

        public string? ostvarenaPovrsina { get; set; }

        public bool zabrana { get; set; }

        public DateTime pocetakZabrane { get; set; }

        public int duzinaZabrane { get; set; }

        public DateTime prestanakZabrane { get; set; }

        public Guid? ovlascenoLiceID { get; set; }
        public Guid prioritetID { get; set; }

        public string? lice { get; set; }

        public string? brTel1 { get; set; }

        public string? brTel2 { get; set; }

        public Guid adresaID { get; set; }

        public Guid uplataID { get; set; }

        public string? email { get; set; }

        public string? brRacuna { get; set; }

    }
}
