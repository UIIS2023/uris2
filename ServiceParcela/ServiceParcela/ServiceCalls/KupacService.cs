using ServiceParcela.DtoModels;

namespace ServiceParcela.ServiceCalls
{
    /// <summary>
    /// KupacService
    /// </summary>
    ///
    public class KupacService : IKupacService
    {
        /// <summary>
        /// KupacService
        /// </summary>
        ///
        public KupacService()
        {
        }

        /// <summary>
        /// getKupci
        /// </summary>
        ///
        public Task<KupacDto> getKupci(Guid kupacId)
        {
            KupacDto kupac = new KupacDto();
            kupac.kupacID = Guid.Parse("b7168998-d4c9-477b-aa30-84bdc3c490b4");
            kupac.fizickoPravnoLice = true;
            kupac.osvarenaPovrsina = "150";
            kupac.zabrana = true;
            kupac.pocetakZabrane = DateTime.Parse("16-06-2022");
            kupac.duzinaZabrane = 2;
            kupac.prestanakZabrane = DateTime.Parse("16-06-2022");
            kupac.ovlascenoLiceId = Guid.Parse("b7168998-d4c9-477b-aa30-84bdc3c490b4");
            kupac.prioritetId = Guid.Parse("b7168998-d4c9-477b-aa30-84bdc3c490b4");
            kupac.brRacuna = "1111";
            kupac.brTel1 = "06254339";
            kupac.brTel2 = "063985452";
            kupac.email = "kupac@gmail.com";
            kupac.lice = "lice";
            kupac.adresaId = Guid.Parse("b7168998-d4c9-477b-aa30-84bdc3c490b4");

            return Task.FromResult<KupacDto>(kupac);
        }
    }
}
