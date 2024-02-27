using System;
namespace KorisnikService.DtoModels
{
    /// <summary>
    /// Klasa korisnik update dto
    /// </summary>
    public class KorisnikUpdateDto
	{
        /// <summary>
        /// Korisnik id
        /// </summary>
        public Guid korisnikId { get; set; }
        /// <summary>
        /// Tip korisnika id
        /// </summary>
        public Guid tipKorisnikaId { get; set; }
        /// <summary>
        /// Ime 
        /// </summary>
        public string? ime { get; set; }
        /// <summary>
        /// Prezime
        /// </summary>
        public string? prezime { get; set; }
        /// <summary>
        /// Korisnicko ime
        /// </summary>
        public string? korisnickoIme { get; set; }
        /// <summary>
        /// Lozinka
        /// </summary>
        public string? lozinka { get; set; }
    }
}

