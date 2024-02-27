using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UgovorZakupService.DtoModels;
using UgovorZakupService.Entities;
using UgovorZakupService.Repository;

namespace UgovorZakupService.ServiceCalls
{
    public class KupacService : IKupacService
    {
        public KupacService() { }

        public Task<KupacDto> getKupac(Guid kupacID) 
        {
            KupacDto kupac = new KupacDto();

            kupac.kupacID = Guid.Parse("{067D272B-3B24-4CC9-B848-319AFAF96E01}");
            kupac.fizickoPravnoLice = false;
            kupac.ostvarenaPovrsina = "123";
            kupac.zabrana = false;
            kupac.pocetakZabrane = DateTime.Parse("2022-12-12");
            kupac.duzinaZabrane = 1;
            kupac.prestanakZabrane = DateTime.Parse("2022-12-22");
            kupac.prioritetID = Guid.Parse("{4E2DD160-0012-4C16-A692-462E59938B06}");
            kupac.lice = "test lice";
            kupac.brTel1 = "061111111";
            kupac.brTel2 = "062222222";
            kupac.adresaID = Guid.Parse("{C46C3A15-B041-464D-AF9F-ED995034712F}");
            kupac.uplataID = Guid.Parse("{F7B4B27F-6075-425C-B5BB-EC95017DD9FC}");
            kupac.email = "test@gmail.com";
            kupac.brRacuna = "123456789";

            return Task.FromResult<KupacDto>(kupac);
        }
    }
}
