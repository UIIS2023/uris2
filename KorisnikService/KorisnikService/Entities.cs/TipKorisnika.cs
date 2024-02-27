using System;
namespace KorisnikService.Entities
{
	public class TipKorisnika
	{
        /// <summary>
        /// Korisnik id
        /// </summary>
        public Guid tipKorisnikaId { get; set; }
        /// <summary>
        /// Uloga korisnika
        /// </summary>
        public string uloga { get; set; }
	}
}

