using System;
using AuctionService.DtoModels;

namespace AuctionService.ServiceCalls
{
    /// <summary>
    /// Interfejs adresaService
    /// </summary>
    public interface IAdresaService
	{
        /// <summary>
        /// Metoda za komunikaciju sa adresa servisom
        /// </summary>
        Task<AdresaDto> getAdresa(Guid adresaId);
	}
}

