using System;
using System.ComponentModel.DataAnnotations;

namespace AuctionService.DtoModels
{
	public class AdresaDto
	{
        /// <summary>
        /// Id adrese
        /// </summary>
        /// 
           
			public Guid AdresaId { get; set; }
        /// <summary>
        /// Ulica
        /// </summary>
        /// 
        public string Ulica { get; set; }
        /// <summary>
        /// Broj ulice
        /// </summary>
        /// 
        public string Mesto { get; set; }
        /// <summary>
        /// Mesto
        /// </summary>
        /// 
        public string PostanskiBroj { get; set; }
        /// <summary>
        /// Drzava
        /// </summary>
        /// 
  

		
	}
}

