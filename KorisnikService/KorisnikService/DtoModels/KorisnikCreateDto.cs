using System;
namespace KorisnikService.DtoModels
{
	public class KorisnikCreateDto
	{
        /// <summary>
        /// tip korisnika id
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
        /// Korisnisko ime
        /// </summary>
        public string? korisnickoIme { get; set; }
        /// <summary>
        /// Lozinka
        /// </summary>
        public string? lozinka { get; set; }
	}
}

