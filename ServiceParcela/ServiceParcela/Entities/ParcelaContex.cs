using Microsoft.EntityFrameworkCore;

namespace ServiceParcela.Entities
{
    /// <summary>
    /// ParcelaContext
    /// </summary>
    /// 
    public class ParcelaContex : DbContext
    {
        /// <summary>
        /// Context
        /// </summary>
        /// 
        public ParcelaContex(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// Parcela
        /// </summary>
        /// 
        public DbSet<Parcela> parcele { get; set; }
        /// <summary>
        /// Deo parcele
        /// </summary>
        /// 
        public DbSet<DeoParcele> deloviParcele { get; set; }
        /// <summary>
        /// Katastarska opstina
        /// </summary>
        /// 
        public DbSet<KatastarskaOpstina> katastarskeOpstine { get; set; }
        /// <summary>
        /// Klasa
        /// </summary>
        /// 
        public DbSet<Klasa> klase { get; set; }
        /// <summary>
        /// Kultura
        /// </summary>
        /// 
        public DbSet<Kultura> kulture { get; set; }
        /// <summary>
        /// Oblik svojine
        /// </summary>
        /// 
        public DbSet<OblikSvojine> obliciSvojine { get; set; }
        /// <summary>
        /// Obradivost
        /// </summary>
        /// 
        public DbSet<Obradivost> obradivosti { get; set; }
        /// <summary>
        /// Odvodnjavanje
        /// </summary>
        /// 
        public DbSet<Odvodnjavanje> odvodnjavanja { get; set; }
        /// <summary>
        /// Zasticena zona
        /// </summary>
        /// 
        public DbSet<ZasticenaZona> zasticeneZone { get; set; }

        /// <summary>
        /// Podaci
        /// </summary>
        /// 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeoParcele>()
              .HasData(new
              {
                  deoParceleID = Guid.Parse("5d5a016a-b9c8-4bcd-9824-eec0106b32a8"),
                  parcelaID = Guid.Parse("b6194c5f-217a-40a4-99c2-5430096d02db"),
                  idealniDeoParcele = 40,
                  stvarniDeoParcele = 60
              });
            modelBuilder.Entity<DeoParcele>()
              .HasData(new
              {
                  deoParceleID = Guid.Parse("61d33f97-6b7e-4aa6-adc5-c307e0da50c3"),
                  parcelaID = Guid.Parse("b6194c5f-217a-40a4-99c2-5430096d02db"),
                  idealniDeoParcele = 55,
                  stvarniDeoParcele = 45
              });

            modelBuilder.Entity<KatastarskaOpstina>()
               .HasData(new
               {
                   katastarskaOpstinaID = Guid.Parse("b41c324d-a885-46ce-93c6-2cf38df6c679"),
                   nazivKatastarskeOpstine = "Čantavir"
               });
            modelBuilder.Entity<KatastarskaOpstina>()
              .HasData(new
              {
                  katastarskaOpstinaID = Guid.Parse("c4e673a1-b52b-4f09-afe4-2d8cd0612ffa"),
                  nazivKatastarskeOpstine = "Bački Vinogradi"
              });
            modelBuilder.Entity<KatastarskaOpstina>()
              .HasData(new
              {
                  katastarskaOpstinaID = Guid.Parse("807391fc-b3f1-4b69-a6a7-c48d54585387"),
                  nazivKatastarskeOpstine = "Bikovo"
              });
            modelBuilder.Entity<KatastarskaOpstina>()
              .HasData(new
              {
                  katastarskaOpstinaID = Guid.Parse("9514b1b3-0d7a-49ae-80ba-46f9df420083"),
                  nazivKatastarskeOpstine = "Đuđin"
              });
            modelBuilder.Entity<KatastarskaOpstina>()
              .HasData(new
              {
                  katastarskaOpstinaID = Guid.Parse("2a366ea1-1141-4d68-a544-3bbdcfb153ba"),
                  nazivKatastarskeOpstine = "Žednik"
              });
            modelBuilder.Entity<KatastarskaOpstina>()
              .HasData(new
              {
                  katastarskaOpstinaID = Guid.Parse("3c13042d-4c28-470b-b512-b6d1bc2c343e"),
                  nazivKatastarskeOpstine = "Tavankut"
              });
            modelBuilder.Entity<KatastarskaOpstina>()
              .HasData(new
              {
                  katastarskaOpstinaID = Guid.Parse("d351326d-624e-454d-b459-e4b145a2b3c8"),
                  nazivKatastarskeOpstine = "Bajmok"
              });
            modelBuilder.Entity<KatastarskaOpstina>()
              .HasData(new
              {
                  katastarskaOpstinaID = Guid.Parse("954d582c-134f-462e-b634-d4eb99d76369"),
                  nazivKatastarskeOpstine = "Donji Grad"
              });
            modelBuilder.Entity<KatastarskaOpstina>()
              .HasData(new
              {
                  katastarskaOpstinaID = Guid.Parse("1a1de9ad-916b-4b43-adda-d5a1783c4a8d"),
                  nazivKatastarskeOpstine = "Stari Grad"
              });
            modelBuilder.Entity<KatastarskaOpstina>()
              .HasData(new
              {
                  katastarskaOpstinaID = Guid.Parse("5c6c9e3b-ddba-4cf9-ae71-eceed1f41989"),
                  nazivKatastarskeOpstine = "Novi Grad"
              });
            modelBuilder.Entity<KatastarskaOpstina>()
              .HasData(new
              {
                  katastarskaOpstinaID = Guid.Parse("c1ef2536-0329-4cc9-b8a9-307e6a259471"),
                  nazivKatastarskeOpstine = "Palić"
              });

            modelBuilder.Entity<Klasa>()
                .HasData(new
                {
                    klasaID = Guid.Parse("ea46fc42-300c-42bd-85ec-b41864c5bfc8"),
                    nazivKlase = "I"
                });
            modelBuilder.Entity<Klasa>()
                .HasData(new
                {
                    klasaID = Guid.Parse("8b479542-bc13-4b6e-8139-f2dc2c47ae74"),
                    nazivKlase = "II"
                });
            modelBuilder.Entity<Klasa>()
                .HasData(new
                {
                    klasaID = Guid.Parse("14791175-a1d8-4ce1-81ce-ab25bc9af38e"),
                    nazivKlase = "III"
                });
            modelBuilder.Entity<Klasa>()
                .HasData(new
                {
                    klasaID = Guid.Parse("17a15c54-c4d3-40a1-b531-2b142aadb2c8"),
                    nazivKlase = "IV"
                });
            modelBuilder.Entity<Klasa>()
                .HasData(new
                {
                    klasaID = Guid.Parse("8adefb3d-8818-4c27-b6c2-276b4063d619"),
                    nazivKlase = "V"
                });
            modelBuilder.Entity<Klasa>()
                .HasData(new
                {
                    klasaID = Guid.Parse("8ed8e0eb-fae8-4de9-9916-1e7f84625d2c"),
                    nazivKlase = "VI"
                });
            modelBuilder.Entity<Klasa>()
                .HasData(new
                {
                    klasaID = Guid.Parse("459a1c86-2562-4599-a1ce-d5259c4a30db"),
                    nazivKlase = "VII"
                });
            modelBuilder.Entity<Klasa>()
                .HasData(new
                {
                    klasaID = Guid.Parse("50bfacfe-4048-4bfe-ab1f-5beaeb33e01c"),
                    nazivKlase = "VIII"
                });

            modelBuilder.Entity<Kultura>()
                .HasData(new
                {
                    kulturaID = Guid.Parse("1af29038-928a-46c1-9bee-3d0532b04dea"),
                    nazivKulture = "Njive"
                });
            modelBuilder.Entity<Kultura>()
                .HasData(new
                {
                    kulturaID = Guid.Parse("42b48292-0521-4caa-bb61-46a8cbdb9d3a"),
                    nazivKulture = "Vrtovi"
                });
            modelBuilder.Entity<Kultura>()
                .HasData(new
                {
                    kulturaID = Guid.Parse("e41f48a3-97a3-4093-b375-0b352b2e3802"),
                    nazivKulture = "Voćnjaci"
                });
            modelBuilder.Entity<Kultura>()
                .HasData(new
                {
                    kulturaID = Guid.Parse("29517569-fd26-48dd-a646-0b52790ca6f2"),
                    nazivKulture = "Vinogradi"
                });
            modelBuilder.Entity<Kultura>()
                .HasData(new
                {
                    kulturaID = Guid.Parse("b846877d-225d-45f6-a926-0a9def92e7f4"),
                    nazivKulture = "Livade"
                });
            modelBuilder.Entity<Kultura>()
                .HasData(new
                {
                    kulturaID = Guid.Parse("0245a22d-684b-4e81-8395-08dfe8c6dac8"),
                    nazivKulture = "Pašnjaci"
                });
            modelBuilder.Entity<Kultura>()
                .HasData(new
                {
                    kulturaID = Guid.Parse("055e4525-4401-455a-b5a7-7080803e9efb"),
                    nazivKulture = "Šume"
                });
            modelBuilder.Entity<Kultura>()
                .HasData(new
                {
                    kulturaID = Guid.Parse("2d4eeed9-0e71-42cb-8da1-1957f470a1ff"),
                    nazivKulture = "Trstici-močvare"
                });

            modelBuilder.Entity<OblikSvojine>()
               .HasData(new
               {
                   oblikSvojineID = Guid.Parse("e174e16d-07ef-43fd-9063-02e6cbc268ca"),
                   nazivOblikaSvojine = "Privatna svojina"
               });
            modelBuilder.Entity<OblikSvojine>()
               .HasData(new
               {
                   oblikSvojineID = Guid.Parse("81878ece-4026-40cb-9cf5-077193071211"),
                   nazivOblikaSvojine = "Državna svojina RS"
               });

            modelBuilder.Entity<OblikSvojine>()
               .HasData(new
               {
                   oblikSvojineID = Guid.Parse("ff6aca81-f31b-406e-b90a-f176882e74e8"),
                   nazivOblikaSvojine = "Državna svojina"
               });
            modelBuilder.Entity<OblikSvojine>()
               .HasData(new
               {
                   oblikSvojineID = Guid.Parse("a828ee07-dac0-44a4-9448-d85a67e4ccf1"),
                   nazivOblikaSvojine = "Društvena svojina"
               });
            modelBuilder.Entity<OblikSvojine>()
               .HasData(new
               {
                   oblikSvojineID = Guid.Parse("235cfc03-763b-4ed2-9353-65a0898d6ab0"),
                   nazivOblikaSvojine = "Zadružna svojina"
               });
            modelBuilder.Entity<OblikSvojine>()
               .HasData(new
               {
                   oblikSvojineID = Guid.Parse("09d1cc19-a993-491e-8bc1-2481f9475a1e"),
                   nazivOblikaSvojine = "Mešovita svojina"
               });

            modelBuilder.Entity<OblikSvojine>()
               .HasData(new
               {
                   oblikSvojineID = Guid.Parse("ac2a129f-03da-4e0c-9ad6-5ab63f13a8b5"),
                   nazivOblikaSvojine = "Drugi oblici"
               });

            modelBuilder.Entity<Obradivost>()
               .HasData(new
               {
                   obradivostID = Guid.Parse("e3c5f27b-8757-4026-8131-19c127395922"),
                   nazivObradivosti = "Obradivo"
               });
            modelBuilder.Entity<Obradivost>()
               .HasData(new
               {
                   obradivostID = Guid.Parse("70928335-ad90-4a80-b672-99319f915698"),
                   nazivObradivosti = "Ostalo"
               });

            modelBuilder.Entity<Odvodnjavanje>()
               .HasData(new
               {
                   odvodnjavanjeID = Guid.Parse("bfd7815f-b9d8-4032-bfcf-9c400c49bc99"),
                   nazivOdvodnjavanja = "Odvodnjavano"
               });
            modelBuilder.Entity<Odvodnjavanje>()
               .HasData(new
               {
                   odvodnjavanjeID = Guid.Parse("389eab9c-5869-4745-a838-0b9211c227a3"),
                   nazivOdvodnjavanja = "Ostalo"
               });

            modelBuilder.Entity<ZasticenaZona>()
               .HasData(new
               {
                   zasticenaZonaID = Guid.Parse("0ff62375-b94c-4415-9ae0-096bb738b8bc"),
                   nazivZasticeneZone = "1"
               });
            modelBuilder.Entity<ZasticenaZona>()
               .HasData(new
               {
                   zasticenaZonaID = Guid.Parse("ef917114-63cd-43c0-a760-e5657f7581c6"),
                   nazivZasticeneZone = "2"
               });
            modelBuilder.Entity<ZasticenaZona>()
               .HasData(new
               {
                   zasticenaZonaID = Guid.Parse("7f2f2e22-6324-4c77-a05e-de203e9d4045"),
                   nazivZasticeneZone = "3"
               });
            modelBuilder.Entity<ZasticenaZona>()
               .HasData(new
               {
                   zasticenaZonaID = Guid.Parse("9aa1cd9b-6e6c-4a9e-8840-641070ab5246"),
                   nazivZasticeneZone = "4"
               });

            modelBuilder.Entity<Parcela>()
               .HasData(new
               {
                   parcelaID = Guid.Parse("b6194c5f-217a-40a4-99c2-5430096d02db"),
                   povrsina = 1152,
                   brojParcele = "123",
                   katastarskaOpstinaID = Guid.Parse("b41c324d-a885-46ce-93c6-2cf38df6c679"),
                   klasaID = Guid.Parse("ea46fc42-300c-42bd-85ec-b41864c5bfc8"),
                   korisnikParceleID = Guid.Parse("a182e614-9937-4391-8eaf-32e15e072f7f"),
                   brojListaNepokretnosti = "23",
                   kulturaID = Guid.Parse("1af29038-928a-46c1-9bee-3d0532b04dea"),
                   obradivostID = Guid.Parse("e3c5f27b-8757-4026-8131-19c127395922"),
                   zasticenaZonaID = Guid.Parse("9aa1cd9b-6e6c-4a9e-8840-641070ab5246"),
                   oblikSvojineID = Guid.Parse("ac2a129f-03da-4e0c-9ad6-5ab63f13a8b5"),
                   odvodnjavanjeID = Guid.Parse("389eab9c-5869-4745-a838-0b9211c227a3"),
                   obradivostStvarnoStanje = "da",
                   kulturaStvarnoStanje = "da",
                   klasaStvarnoStanje = "da",
                   zasticenaZonaStvarnoStanje = "da",
                   odvodnjavanjeStvarnoStanje = "da"
               });
            modelBuilder.Entity<Parcela>()
               .HasData(new
               {
                   parcelaID = Guid.Parse("ed20eaf8-65ff-4a29-a564-ad7cfc08f7a2"),
                   povrsina = 1362,
                   brojParcele = "124",
                   katastarskaOpstinaID = Guid.Parse("c4e673a1-b52b-4f09-afe4-2d8cd0612ffa"),
                   klasaID = Guid.Parse("50bfacfe-4048-4bfe-ab1f-5beaeb33e01c"),
                   korisnikParceleID = Guid.Parse("76308391-c1e7-450f-b36c-c289f7562116"),
                   brojListaNepokretnosti = "43",
                   kulturaID = Guid.Parse("42b48292-0521-4caa-bb61-46a8cbdb9d3a"),
                   obradivostID = Guid.Parse("70928335-ad90-4a80-b672-99319f915698"),
                   zasticenaZonaID = Guid.Parse("0ff62375-b94c-4415-9ae0-096bb738b8bc"),
                   oblikSvojineID = Guid.Parse("235cfc03-763b-4ed2-9353-65a0898d6ab0"),
                   odvodnjavanjeID = Guid.Parse("bfd7815f-b9d8-4032-bfcf-9c400c49bc99"),
                   obradivostStvarnoStanje = "da",
                   kulturaStvarnoStanje = "da",
                   klasaStvarnoStanje = "da",
                   zasticenaZonaStvarnoStanje = "da",
                   odvodnjavanjeStvarnoStanje = "da"
               });
        }
    }
}
