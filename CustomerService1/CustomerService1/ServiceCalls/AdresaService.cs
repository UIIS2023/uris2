using CustomerService1.Models;

namespace CustomerService1.ServiceCalls
{
    public class AdresaService : IAdresaService
    {
        public AdresaService() 
        {
        }
        /// <summary>
        /// Metoda vraca adresu
        /// </summary>
        /// <param name="adresaId">Id adrese</param>
        /// <returns>Adresa</returns>
        public Task<AdresaDto> getAdresa(Guid adresaId)
        {
            AdresaDto adresa = new AdresaDto();
            adresa.adresaId = Guid.Parse("a215e4cb-a427-40cf-88b2-8488d140a939");
            adresa.broj = "19";
            adresa.Drzava = "Srbija";
            adresa.mesto = "Novi Sad";
            adresa.postanskiBroj = "21000";
            adresa.ulica = "Gogoljeva 21";

            return Task.FromResult<AdresaDto>(adresa);
        }
    }
}
