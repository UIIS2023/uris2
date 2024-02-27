using System;
namespace KorisnikService.DtoModels
{
    /// <summary>
    /// Tip korisnika update dto
    /// </summary>
    public class TipKorisnikaUpdateDto
	{
        /// <summary>
        /// Tip korisnika id 
        /// </summary>
        public Guid TipKorisnikaId { get; set; }
        /// <summary>
        /// Uloga
        /// </summary>
        public string? uloga { get; set; }
    }
}

