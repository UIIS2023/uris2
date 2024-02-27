using System;
namespace KorisnikService.DtoModels
{
    /// <summary>
    /// Korisnik DTO
    /// </summary>
    public class KorisnikDto
	{
        /// <summary>
        /// id korisnika
        /// </summary
        public Guid korisnikId { get; set; }
        /// <summary>
        /// Tip korisnika id
        /// </summary>
        public Guid tipKorisnikaId { get; set; }
        /// <summary>
        /// Ime korisnika
        /// </summary>
        public string? ime { get; set; }
        /// <summary>
        /// Prezime korisnika
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

