using System;
using System.ComponentModel.DataAnnotations;

namespace AuctionService.DtoModels
{
	public class KupacDto
	{
        /// <summary>
        /// Id kupca
        /// </summary>
        public Guid KupacID { get; set; }
        /// <summary>
        /// Fizicko ili pravno lice
        /// </summary>
        public bool FizPravno { get; set; }
        /// <summary>
        /// Ostvarena povrsina kupca
        /// </summary>
        public string OstvarenaPovrsina { get; set; }
        /// <summary>
        /// Broj telefona kupca
        /// </summary>
        public string BrTel1 { get; set; }
        /// <summary>
        /// Email kupca
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Broj racuna kupca
        /// </summary>
        public string BrojRacuna { get; set; }
    }
}

