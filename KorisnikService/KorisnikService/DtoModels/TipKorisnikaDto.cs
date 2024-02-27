using System;
namespace KorisnikService.DtoModels
{
    /// <summary>
    /// Naziv dto klase
    /// </summary>
    public class TipKorisnikaDto
	{
        /// <summary>
        /// Korisnik id
        /// </summary>
        public Guid tipKorisnikaId { get; set; }
        /// <summary>
        /// Uloga
        /// </summary>
        public string uloga { get; set; }
	}
}

