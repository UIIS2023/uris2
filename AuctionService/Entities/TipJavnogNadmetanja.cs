using System;
using System.ComponentModel.DataAnnotations;

namespace AuctionService.Entities
{

    public class TipJavnogNadmetanja
    {
        /// <summary>
        /// Id tipa nadmetanja
        /// </summary>
        /// 
        [Key]
        public Guid tipJavnogNadmetanjaID { get; set; }

        /// <summary>
        /// Naziv tipa nadmetanja
        /// </summary>
        /// 
        //naziv tipa javnog nadmetanja
        public string nazivTipa { get; set; }
    }
}
