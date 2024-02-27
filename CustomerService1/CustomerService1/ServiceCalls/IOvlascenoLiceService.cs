using CustomerService1.Models;

namespace CustomerService1.ServiceCalls
{
    public interface IOvlascenoLiceService
    {
        /// <summary>
        /// Metoda vraca ovlasceno lice
        /// </summary>
        /// <param name="ovlascenoLice">Id ovlascenog lica</param>
        /// <returns>Ovlasceno lice</returns>
        Task<OvlascenoLiceDto> getOvlascenoLice(Guid ovlascenoLice);
    }
}
