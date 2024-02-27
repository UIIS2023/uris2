using System;
using System.ComponentModel.DataAnnotations;

namespace AuctionService.DtoModels
{
	public class OvlascenoLiceDto
	{

        /// <summary>
        /// Ime ovlascenog lica
        /// </summary>
        /// 
        public Guid OvlascenoLiceID { get; set; }

        /// <summary>
        /// Ime
        /// </summary>
        /// 
        public string Ime { get; set; }

        /// <summary>
        /// Prezime ovlascenog lica
        /// </summary>
        ///
        public string Prezime { get; set; }

        /// <summary>
        /// Broj dokumenta
        /// </summary>
        /// 
        public string BrojDokumenta { get; set; }
        /// <summary>
        /// Broj table ovlascenog lica
        /// </summary>
        /// 
        public string BrojTable { get; set; }
        /// <summary>
        /// Adresa ovlascenog lica
        /// </summary>
        /// 
        public Guid AdresaID { get; set; }
    }
}

