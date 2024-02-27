using System;
using AuctionService.DtoModels;

namespace AuctionService.ServiceCalls
{
	public interface IOvlascenoLiceService
	{
        /// <summary>
        /// Metoda za komunikaciju sa ovlascenim licem 
        /// </summary>
        Task<OvlascenoLiceDto> getOvlascenoLice(Guid ovlascenoLice);
	}
}

