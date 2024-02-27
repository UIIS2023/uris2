using CustomerService1.Models;

namespace CustomerService1.ServiceCalls
{
    public class OvlascenoLiceService : IOvlascenoLiceService
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        public OvlascenoLiceService() { }
        /// <summary>
        /// Metoda vraca ovlsdceno lice
        /// </summary>
        /// <param name="ovlascenoLice">Id ovlascenog lica</param>
        /// <returns>Ovlasceno lice</returns>
        public Task<OvlascenoLiceDto> getOvlascenoLice(Guid ovlascenoLice)
        {
            OvlascenoLiceDto oLice = new OvlascenoLiceDto();
            oLice.ovlascenoLiceId = Guid.Parse("a215e4cb-a427-40cf-88b2-8488d140a939");
            oLice.ime = "Sandra";
            oLice.prezime = "Lazic";
            oLice.brojTabli = new List<int> { 1, 2, 3 };

            return Task.FromResult<OvlascenoLiceDto>(oLice);
        }
    }
}
