using CustomerService1.Models;

namespace CustomerService1.ServiceCalls
{
    public interface IAdresaService
    {
        /// <summary>
        /// Metoda vraca adresu
        /// </summary>
        /// <param name="adresaId">Id adrese</param>
        /// <returns>Adresa</returns>
        Task<AdresaDto> getAdresa(Guid adresaId);
    }
}
