using System;
using System.ComponentModel.DataAnnotations;

namespace AuctionService.DtoModels
{
	public class TipJavnogNadmetanjaUpdateDto
	{
        /// <summary>
        /// Id tipa nadmetanja
        /// </summary>
        /// 
        
		public Guid tipJavnogNadmetanjaID { get; set; }

        /// <summary>
        /// Naziv tipa nadmetanja
        /// </summary>
        /// 
		public string nazivTipa { get; set; }
	}
}

