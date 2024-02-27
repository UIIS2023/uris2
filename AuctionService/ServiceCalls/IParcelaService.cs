using System;
using AuctionService.DtoModels;

namespace AuctionService.ServiceCalls
{
	public interface IParcelaService
	{
        /// <summary>
        /// Metoda za preuzimanje podataka o parceli
        /// </summary>
        Task<ParcelaDto> getParcela(Guid parcelaId);
	}
}

