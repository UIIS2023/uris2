using AutoMapper;
using CustomerService1.Entities;

namespace CustomerService1.Data
{
    public class KupacRepository : IKupacRepository
    {
        public static List<Kupac> kupacs { get; set; } = new List<Kupac>();
        private readonly IMapper mapper;
        private readonly KupacContext context;


        public KupacRepository(IMapper mapper,  KupacContext context)
        {
           // FillData();
            this.mapper = mapper;
            this.context = context;

        }
        /*
        private void FillData()
        {
            kupacs.AddRange(new List<Kupac>
            {
                new Kupac
                {
                   KupacID= Guid.Parse("208a48a5-371c-4f9d-ac23-18bb176ff8f3"),
                   FizPravno= true,
                   OstvarenaPovrsina= "povrsina",
                   Zabrana = true,
                   PocetakZabrane = DateTime.Parse("2022-2-17"),
                   DuzinaZabrane= "duzina",
                   PrestanakZabrane= DateTime.Parse("2022-2-22"),
                   OvlascenoLiceID = Guid.Parse("4246a611-7b2f-429d-a9ba-0e539c81b82f"),
                   PrioritetID= Guid.Parse("8aaa90c8-56f3-4a76-b07a-f895eded5a84"),
                   BrTel1= "0645894522",
                   BrTel2= "0695844365",
                   AdresaID= Guid.Parse("4246a611-7b2f-429d-a9ba-0e539c81b82f"),
                   UplataID= Guid.Parse("8aaa90c8-56f3-4a76-b07a-f895eded5a84"),
                   Email= "nikola@gmail.com",
                   BrojRacuna= "0065482-56"
                },
                new Kupac
                {
                    KupacID= Guid.Parse("b7b2fe75-17cf-47cc-b4bb-517e5e4e20e6"),
                   FizPravno= true,
                   OstvarenaPovrsina= "povrsina1",
                   Zabrana = true,
                   PocetakZabrane = DateTime.Parse("2022-2-10"),
                   DuzinaZabrane= "duzina1",
                   PrestanakZabrane= DateTime.Parse("2022-2-25"),
                   OvlascenoLiceID = Guid.Parse("5cc5ad76-335d-4627-8d5d-552da874fb07"),
                   PrioritetID= Guid.Parse("8119972a-4c62-4072-aa09-3fd98b733f95"),
                   BrTel1= "0655684251",
                   BrTel2= "0695413775",
                   AdresaID= Guid.Parse("1f7e948d-6b19-47d3-95dd-d3e3c405572b"),
                   UplataID= Guid.Parse("217c5272-fadd-4290-a981-ed18ab49635b"),
                   Email= "natalija@gmail.com",
                   BrojRacuna= "068845974-458-6"
                }
            });
        }*/

        public void deleteKupac(Guid id)
        {
            Entities.Kupac kupac = getKupacById(id);
            context.kupci.Remove(kupac);
        }

        public List<Kupac> getAllKupci()
        {
            return context.kupci.ToList();
        }

        public Kupac getKupacById(Guid id)
        {
            return context.kupci.FirstOrDefault(ku => ku.KupacID == id);
        }

        public KupacConfirmation postKupac(Kupac kupac)
        {
            kupac.KupacID = Guid.NewGuid();
            var noviKupac = context.kupci.Add(kupac);
            return mapper.Map<KupacConfirmation>(kupac);
            /* kupac.KupacID = Guid.NewGuid();
             kupacs.Add(kupac);
             Kupac ku = getKupacById(kupac.KupacID);
             return new KupacConfirmation
             {
                 KupacID = ku.KupacID,
                 FizPravno = ku.FizPravno,
                 OstvarenaPovrsina = ku.OstvarenaPovrsina,
                 BrTel1= ku.BrTel1,
                 Email= ku.Email,
                 BrojRacuna= ku.BrojRacuna,

             };*/
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public KupacConfirmation updateKupac(Kupac kupac)
        {
            Kupac ku = getKupacById(kupac.KupacID);
            ku.KupacID = kupac.KupacID;
            ku.FizPravno = kupac.FizPravno;
            ku.OstvarenaPovrsina = kupac.OstvarenaPovrsina;
            ku.Zabrana = kupac.Zabrana;
            ku.PocetakZabrane = kupac.PocetakZabrane;
            ku.DuzinaZabrane = kupac.DuzinaZabrane;
            ku.PrestanakZabrane = kupac.PrestanakZabrane;
            ku.OvlascenoLice = kupac.OvlascenoLice;
            ku.PrioritetID = kupac.PrioritetID;
            ku.BrTel1 = kupac.BrTel1;
            ku.BrTel2 = kupac.BrTel2;
            ku.AdresaID = kupac.AdresaID;
            ku.UplataID = kupac.UplataID;
            ku.Email = kupac.Email;
            ku.BrojRacuna = kupac.BrojRacuna;
            
            return new KupacConfirmation
            {
                KupacID = ku.KupacID,
                FizPravno = ku.FizPravno,
                OstvarenaPovrsina = ku.OstvarenaPovrsina,
                BrTel1= ku.BrTel1,
                Email= ku.Email,
                BrojRacuna= ku.BrojRacuna
                
            };
        }
    }
}
