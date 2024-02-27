using System;
using AuctionService.DtoModels;

namespace AuctionService.ServiceCalls
{
	public interface IKupacService
	{
        /// <summary>
        /// Metoda za komunikaciju sa kupac servisom
        /// </summary>
        Task<KupacDto> getKupci(Guid kupacId);
	}
}

