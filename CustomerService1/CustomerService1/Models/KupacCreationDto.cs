
using System.ComponentModel.DataAnnotations;

namespace CustomerService1.Models
{
    /// <summary>
    /// DTO za kreiranje kupca
    /// </summary>
    public class KupacCreationDto : IValidatableObject
    {
        /// <summary>
        /// Fizicko ili pravno lice
        /// </summary>
        public bool FizPravno { get; set; }
        /// <summary>
        /// Ostvarena povrsina
        /// </summary>
        public string? OstvarenaPovrsina { get; set; }
        /// <summary>
        /// Da li kupac ima zabranu
        /// </summary>
        public bool Zabrana { get; set; }
        /// <summary>
        /// Datum pocetka zabrane kupca
        /// </summary>
        public DateTime PocetakZabrane { get; set; }
        /// <summary>
        /// Duzina zabrane kupca
        /// </summary>
        public string? DuzinaZabrane { get; set; }
        /// <summary>
        /// Datum prestanka zabrane
        /// </summary>
        public DateTime PrestanakZabrane { get; set; }
        /// <summary>
        /// Ovasceno lice kupca
        /// </summary>
        public Guid? OvlascenoLiceID { get; set; }
        /// <summary>
        /// Prioritet kupca
        /// </summary>
        public Guid PrioritetID { get; set; }
        /// <summary>
        /// Broj telefona 1 kupca
        /// </summary>
        public string? BrTel1 { get; set; }
        /// <summary>
        /// Broj telefona 2 kupca
        /// </summary>
        public string? BrTel2 { get; set; }
        /// <summary>
        /// Adresa kupca
        /// </summary>
        public Guid AdresaID { get; set; }
        /// <summary>
        /// Uplata kupca
        /// </summary>
        public Guid UplataID { get; set; }
        /// <summary>
        /// Email kupca
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Broj racuna kupca
        /// </summary>
        public string? BrojRacuna { get; set; }

        /// <summary>
        /// Metoda za validaciju, proverava se da li us validno upisani datumi pocetka i kraja zabrane
        /// </summary>
        /// <param name="validationContext">Kontekst nad kojim se validacija izvrsava</param>
        /// <returns>Rezultat validacije</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (PocetakZabrane > PrestanakZabrane)
            {
                yield return new ValidationResult(
                    "Pocetak zabrane mora da bude manji od prestanka zabrane.",
                    new[] { "KupacCreationDto" }); //prosledjuje se model nad kojim je nastala greska
            }
        }
    }
}
