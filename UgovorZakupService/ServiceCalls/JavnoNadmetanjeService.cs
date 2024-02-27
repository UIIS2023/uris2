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
    public class JavnoNadmetanjeService : IJavnoNadmetanjeService
    {
        public JavnoNadmetanjeService() { }

        public Task<JavnoNadmetanjeDto> getJavnoNadmetanje(Guid javnoNadmetanjeID)
        {
            JavnoNadmetanjeDto javnoNadmetanje = new JavnoNadmetanjeDto();

            javnoNadmetanje.javnoNadmetanjeID = Guid.Parse("{E9B7661C-14D6-4DB7-9658-7D5B81E7B77E}");
            javnoNadmetanje.datum = DateTime.Parse("2022-12-12");
            javnoNadmetanje.vremePocetka = DateTime.Parse("2022-12-12T08:00:00");
            javnoNadmetanje.vremeKraja = DateTime.Parse("2022-12-12T08:00:00");
            javnoNadmetanje.pocetnaCenaPoHektaru = 123;
            javnoNadmetanje.izuzeto = false;
            javnoNadmetanje.izlicitiranaCena = 123;
            javnoNadmetanje.periodZakupa = 123;
            javnoNadmetanje.brojUcesnika = 12;
            javnoNadmetanje.visinaDopuneDepozita = 123;
            javnoNadmetanje.krug = 1;
            javnoNadmetanje.statusNadmetanjaID = Guid.Parse("{9B464C86-A577-472E-A407-3C012F369910}");
            javnoNadmetanje.tipID = Guid.Parse("{232FB863-5DE3-4E89-81C1-4092A2A8D8C0}");
            javnoNadmetanje.ovlascenoLiceID = Guid.Parse("{BB9D4886-7109-44F8-94B6-7F2C212C8954}");
            javnoNadmetanje.prijavljeniKupciID = new List<Guid> { Guid.Parse("{5BA8EB2D-7ACB-4DFE-8411-63C537799869}"), Guid.Parse("{8653EE3B-94CF-4189-A835-798DF7319643}") };
            javnoNadmetanje.adresaID = Guid.Parse("{13533403-2ACF-43E5-8E75-F9FFFAC65278}");
            javnoNadmetanje.najboljiPonudjacID = Guid.Parse("{40D750C8-A366-41AD-AEBA-BCA3157BA8D6}");
            javnoNadmetanje.parceleID = new List<Guid> { Guid.Parse("{86A8D3A7-9C2A-40E8-A745-4E86F3F44AAB}"), Guid.Parse("{9D4957B2-A2CB-4D02-BB90-D25A4B97CDB9}") };

            return Task.FromResult<JavnoNadmetanjeDto>(javnoNadmetanje);
        }
    }
}
