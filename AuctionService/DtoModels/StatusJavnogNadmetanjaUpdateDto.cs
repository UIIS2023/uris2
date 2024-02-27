using System;
using System.ComponentModel.DataAnnotations;

namespace AuctionService.DtoModels
{
	public class StatusJavnogNadmetanjaUpdateDto
	{
        /// <summary>
        /// Id statusa nadmetanja
        /// </summary>
        /// 
        
		public Guid statusNadmetanjaID { get; set; }

        /// <summary>
        /// Naziv statusa nadmetanja
        /// </summary>
        /// 
		public string naziv {get; set;}
	}
}

