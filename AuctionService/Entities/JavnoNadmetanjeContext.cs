using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AuctionService.Entities
{
    public class JavnoNadmetanjeContext : DbContext
    {
        

        public JavnoNadmetanjeContext(DbContextOptions options) : base(options)
        {
           
        }

        public DbSet<JavnoNadmetanje> javnaNadmetanja { get; set; }
        public DbSet<TipJavnogNadmetanja> tipoviNadmetanja { get; set; }
        public DbSet<StatusNadmetanja> statusiNadmetanja { get; set; }
        public DbSet<Licitacija> licitacije { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipJavnogNadmetanja>()
              .HasData(new
              {
                  tipJavnogNadmetanjaID = Guid.Parse("4246a611-7b2f-429d-a9ba-0e539c81b82f"),
                  nazivTipa = "Javna licitacija"
              });
            modelBuilder.Entity<TipJavnogNadmetanja>()
              .HasData(new
              {
                  tipJavnogNadmetanjaID = Guid.Parse("99b6d6ec-4358-4898-936b-31b31d236324"),
                  nazivTipa = "Otvaranje zatvorenih ponuda"
              });

            modelBuilder.Entity<StatusNadmetanja>()
               .HasData(new
               {
                   statusNadmetanjaID = Guid.Parse("8aaa90c8-56f3-4a76-b07a-f895eded5a84"),
                   naziv = "Prvi krug"
               });
            modelBuilder.Entity<StatusNadmetanja>()
              .HasData(new
              {
                  statusNadmetanjaID = Guid.Parse("b1ad846b-f76f-4485-8c89-08e2dfebd112"),
                  naziv = "Drugi krug sa starim uslovima"
              });
            modelBuilder.Entity<StatusNadmetanja>()
              .HasData(new
              {
                  statusNadmetanjaID = Guid.Parse("d85b4a71-27e4-4626-9a3e-0412430e03d6"),
                  naziv = "Drugi krug sa novim uslovima"
              });

            modelBuilder.Entity<JavnoNadmetanje>()
                .HasData(new
                {
                    javnoNadmetanjeID = Guid.Parse("208a48a5-371c-4f9d-ac23-18bb176ff8f3"),
                    datum = DateTime.Parse("2022-2-17"),
                    vremePocetka = DateTime.Parse("2022-2-17T08:00:00"),//godina, mesec, dan, sat, minut, sekunda
                    vremeKraja = DateTime.Parse("2022-2-17T10:00:00"),
                    pocetnaCenaPoHektaru = 5000,
                    izuzeto = false,
                    tipID = Guid.Parse("4246a611-7b2f-429d-a9ba-0e539c81b82f"),
                    izlicitiranaCena = 7500,
                    periodZakupa = 12,
                    brojUcesnika = 10,
                    visinaDopuneDepozita = 500,
                    krug = 1,
                    statusNadmetanjaID = Guid.Parse("8aaa90c8-56f3-4a76-b07a-f895eded5a84"),
                    adresaID = Guid.Parse("a06f99d2-0ba7-40ff-a241-304a03dfe4be"),
                    ovlascenoLiceID = Guid.Parse("5cfa282f-8324-4a8b-8c23-8d43502ca01e"),
                    najboljiPonudjacID = Guid.Parse("8b3b7775-4293-4b41-9ccc-19f9cf694d68"),
                    
                });

            modelBuilder.Entity<JavnoNadmetanje>()
               .HasData(new
               {
                   javnoNadmetanjeID = Guid.Parse("13d6ced2-ab84-4132-bf67-e96037f4813d"),
                   datum = DateTime.Parse("2022-2-18"),
                   vremePocetka = DateTime.Parse("2022-2-18T08:00:00"),
                   vremeKraja = DateTime.Parse("2022-2-18T10:00:00"),
                   pocetnaCenaPoHektaru = 4000,
                   izuzeto = false,
                   tipID = Guid.Parse("4246a611-7b2f-429d-a9ba-0e539c81b82f"),
                   izlicitiranaCena = 6000,
                   periodZakupa = 12,
                   brojUcesnika = 10,
                   visinaDopuneDepozita = 400,
                   krug = 1,
                   statusNadmetanjaID = Guid.Parse("8aaa90c8-56f3-4a76-b07a-f895eded5a84"),
                   adresaID = Guid.Parse("a06f99d2-0ba7-40ff-a241-304a03dfe4be"),
                   ovlascenoLiceID = Guid.Parse("5cfa282f-8324-4a8b-8c23-8d43502ca01e"),   
                   najboljiPonudjacID = Guid.Parse("8b3b7775-4293-4b41-9ccc-19f9cf694d68"),
                   
               });

            modelBuilder.Entity<Licitacija>()
                .HasData(new
                {
                    licitacijaID = Guid.Parse("a215e4cb-a427-40cf-88b2-8488d140a939"),
                    broj = 1,
                    godina = 2022,
                    datum = DateTime.Parse("2022-2-17"),
                    ogranicenja = 1,
                    korakCene = 100,
                    listaDokumentacijeFizickaLica = new List<string>() { "dok1_fl", "dok2_fl" },
                    listaDokumentacijePravnaLica = new List<string>() { "dok1_pl", "dok1_pl" },
                    javnoNadmetanjeId = Guid.Parse("208a48a5-371c-4f9d-ac23-18bb176ff8f3"),
                    rokZaDostavljanje = DateTime.Parse("2022-2-15")

                });
            modelBuilder.Entity<Licitacija>()
               .HasData(new
               {
                   licitacijaID = Guid.Parse("1de13266-85e8-4120-8b1f-daacc32c5811"),
                   broj = 2,
                   godina = 2022,
                   datum = DateTime.Parse("2022-2-18"),
                   ogranicenja = 1,
                   korakCene = 200,
                   listaDokumentacijeFizickaLica = new List<string>() { "dok1_fl", "dok2_fl" },
                   listaDokumentacijePravnaLica = new List<string>() { "dok1_pl", "dok1_pl" },
                   javnoNadmetanjeId = Guid.Parse("208a48a5-371c-4f9d-ac23-18bb176ff8f3"),
                   rokZaDostavljanje = DateTime.Parse("2022-2-16")
               });
        }
    }
}


