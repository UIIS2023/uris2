using CustomerService1.Models;

namespace CustomerService1.ServiceCalls
{
    public interface IUplataService
    {
        /// <summary>
        /// Metoda vraca uplatu
        /// </summary>
        /// <param name="uplataId">Id uplate</param>
        /// <returns>Uplata</returns>
        Task<UplataDto> getUplata(Guid uplataId);
    }
}
