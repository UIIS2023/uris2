using CustomerService1.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerService1.Entities
{
    public class Kupac
    {
        /// <summary>
        /// Id kupca
        /// </summary>
        public Guid KupacID { get; set; }
        /// <summary>
        /// Fizicko ili pravno lice
        /// </summary>
        public bool FizPravno { get; set; }
        /// <summary>
        /// Ostvarena povrsina kupca
        /// </summary>
        public string OstvarenaPovrsina { get; set; }
        /// <summary>
        /// Zabrana kupca
        /// </summary>
        public bool Zabrana { get; set; }
        /// <summary>
        /// Datum pocetka zabrane
        /// </summary>
        public DateTime PocetakZabrane { get; set; }
        /// <summary>
        /// Duzina zabrane
        /// </summary>
        public string DuzinaZabrane { get; set; }
        /// <summary>
        /// Datum prestanka zabrane
        /// </summary>
        public DateTime PrestanakZabrane { get; set; }
        /// <summary>
        /// Id ovlascenog lica
        /// </summary>
        public Guid? OvlascenoLiceID { get; set; }
        /// <summary>
        /// Id prioriteta
        /// </summary>
        public Guid PrioritetID { get; set; }
        /// <summary>
        /// Broj telefona 1
        /// </summary>
        public string BrTel1 { get; set; }
        /// <summary>
        /// Broj telefona 2
        /// </summary>
        public string BrTel2 { get; set; }
        /// <summary>
        /// Id adrese
        /// </summary>
        public Guid AdresaID { get; set; }
        /// <summary>
        /// Id uplate
        /// </summary>
        public Guid UplataID { get; set; }
        /// <summary>
        /// Email kupca
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Broj racuna
        /// </summary>
        public string BrojRacuna { get; set; }

        [NotMapped]
        public OvlascenoLiceDto OvlascenoLice { get; set; }
        [NotMapped]
        public UplataDto Uplata { get; set; }
        [NotMapped]
        public AdresaDto Adresa { get; set; }

    }
}
