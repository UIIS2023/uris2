using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.DtoModels
{
    
	public class TipNadmetanjaCreationDto
	{
        /// <summary>
        /// Naziv tipa nadmetanja
        /// </summary>
        ///
        [Required(ErrorMessage = "Requires field")]
		public string nazivTipa { get; set; }
	}
}

