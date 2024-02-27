using Microsoft.EntityFrameworkCore;

namespace CustomerService1.Entities
{
    public class KupacContext : DbContext
    {
        public KupacContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Kupac> kupci { get; set; }
        public DbSet<KontaktOsoba> kontaktOsoba { get; set; }
        public DbSet<Prioritet> prioriteti { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kupac>()
                .HasData(new
                {
                    KupacID = Guid.Parse("208a48a5-371c-4f9d-ac23-18bb176ff8f3"),
                    FizPravno = true,
                    OstvarenaPovrsina= "250",
                    Zabrana=true,
                    PocetakZabrane= DateTime.Parse("2021-2-18"),
                    DuzinaZabrane= "1 godina",
                    PrestanakZabrane= DateTime.Parse("2022-2-18"),
                    OvlascenoLiceID= Guid.Parse("e6721431-2b48-442a-a93e-24d8d7c4ef22"),
                    PrioritetID= Guid.Parse("f9a334b1-d69a-4f9d-a7b6-5d22ae04248a"),
                    BrTel1= "0654811935",
                    BrTel2= "5684951",
                    AdresaID= Guid.Parse("778c3ad6-84f9-48ef-a00f-ea109a46a724"),
                    UplataID= Guid.Parse("1f573635-14e0-4211-81fb-ae4211ec3bdb"),
                    Email= "sanja00@gmal.com",
                    BrojRacuna= "56449851"
                }) ;
            modelBuilder.Entity<Kupac>()
                .HasData(new
                {
                    KupacID = Guid.Parse("f352f125-4e69-4cfc-a297-f15e16f14df3"),
                    FizPravno = true,
                    OstvarenaPovrsina = "200",
                    Zabrana = true,
                    PocetakZabrane = DateTime.Parse("2021-2-20"),
                    DuzinaZabrane = "1 godina",
                    PrestanakZabrane = DateTime.Parse("2022-2-20"),
                    OvlascenoLiceID = Guid.Parse("574fd280-fdf3-44e2-bf0a-addfb4c9be53"),
                    PrioritetID = Guid.Parse("b604c2f3-3653-4c55-8555-d3fe41bbae01"),
                    BrTel1 = "0606499581",
                    BrTel2 = "459667",
                    AdresaID = Guid.Parse("c30f6f67-0c74-4165-83bb-2b9525882efb"),
                    UplataID = Guid.Parse("834a56c9-7f9c-46e8-9fac-6345948ba0db"),
                    Email = "asavic@gmal.com",
                    BrojRacuna = "16599874"
                });
            modelBuilder.Entity<KontaktOsoba>()
                .HasData(new
                {
                    KontaktOsobaID = Guid.Parse("8685933f-8b02-450b-aa68-f040f2b0273e"),
                    Ime = "Nikola",
                    Prezime = "Popovic",
                    Funkcija = "funkcija1",
                    Telefon = "0678544256"
                   
                });
            modelBuilder.Entity<KontaktOsoba>()
                .HasData(new
                {
                    KontaktOsobaID = Guid.Parse("2d5cacd8-81da-4e11-b483-4a32a7ea6085"),
                    Ime = "Sandra",
                    Prezime = "Lazic",
                    Funkcija = "funkcija2",
                    Telefon = "0695476115"

                });
            modelBuilder.Entity<Prioritet>()
                .HasData(new
                {
                    PrioritetID = Guid.Parse("f9a334b1-d69a-4f9d-a7b6-5d22ae04248a"),
                    OpisPrioriteta= "Vlasnik sistema za navodnjavanje"

                });
            modelBuilder.Entity<Prioritet>()
                .HasData(new
                {
                    PrioritetID = Guid.Parse("b604c2f3-3653-4c55-8555-d3fe41bbae01"),
                    OpisPrioriteta = " Vlasnik zemljišta koje se graniči sa zemljištem koje se daje u zakup"

                });
            modelBuilder.Entity<Prioritet>()
                .HasData(new
                {
                    PrioritetID = Guid.Parse("87fc1ead-7d94-4d76-b72f-7c340bb73ca7"),
                    OpisPrioriteta = " Poljuprivrednik koji je upisan u registar"

                });
            modelBuilder.Entity<Prioritet>()
                .HasData(new
                {
                    PrioritetID = Guid.Parse("33b1ea56-ef1a-4608-a0a4-6d5fcbdbf7c1"),
                    OpisPrioriteta = " Vlasnik zemljista koji je najblize zemljistu koje se daje u zakup"

                });

        }
        
    }
}
