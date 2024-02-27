using PaymentService1.Models;

namespace PaymentService1.ServiceCalls
{
    public class KupacService : IKupacService
    {
        public KupacService() { }
        public Task<KupacDto> getKupac(Guid kupacId)
        {
            KupacDto kupac = new KupacDto();
            kupac.KupacID = Guid.Parse("a215e4cb-a427-40cf-88b2-8488d140a939");
            kupac.FizPravno = true;
            kupac.OstvarenaPovrsina = "250";
            kupac.BrTel1 = "0601549884";
            kupac.Email = "nn00@gmail.com";
            kupac.BrojRacuna = "455484531";

            return Task.FromResult<KupacDto>(kupac);
        }
    }
}
