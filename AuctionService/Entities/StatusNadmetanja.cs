using System;
using System.ComponentModel.DataAnnotations;

namespace AuctionService.Entities
{
	public class StatusNadmetanja
	{
        /// <summary>
        /// Id statusa nadmetanja
        /// </summary>
        /// 
        //ID status javnog nadmetanja
        [Key]
		public Guid statusNadmetanjaID { get; set; }

        /// <summary>
        /// Naziv statusa nadmetanja
        /// </summary>
        /// 
		public string naziv { get; set; }
	}
}

