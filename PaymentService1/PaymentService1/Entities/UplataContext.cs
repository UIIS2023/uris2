using Microsoft.EntityFrameworkCore;

namespace PaymentService1.Entities
{
    public class UplataContext : DbContext
    {
        public UplataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Uplata> uplate { get; set; }
        public DbSet<KursnaLista> kursneListe { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Uplata>()
               .HasData(new
               {
                   UplataID = Guid.Parse("1f573635-14e0-4211-81fb-ae4211ec3bdb"),
                   brojRacuna = "11659487",
                   pozivNaBroj = "125698",
                   iznos = "15000",
                   uplatilac = Guid.Parse("33b1ea56-ef1a-4608-a0a4-6d5fcbdbf7c1"),
                   svrhaUplate="uplata1",
                   datum= DateTime.Parse("2021-2-18"),
                   javnoNadmetanje= Guid.Parse("208a48a5 - 371c - 4f9d - ac23 - 18bb176ff8f3")

               });
            modelBuilder.Entity<Uplata>()
               .HasData(new
               {
                   UplataID = Guid.Parse("834a56c9-7f9c-46e8-9fac-6345948ba0db"),
                   brojRacuna = "11569847",
                   pozivNaBroj = "125684",
                   iznos = "17000",
                   uplatilac = Guid.Parse("9c46a0be-cad8-440d-a5f2-f4451fff69d7"),
                   svrhaUplate = "uplata2",
                   datum = DateTime.Parse("2021-2-19"),
                   javnoNadmetanje = Guid.Parse("13d6ced2-ab84-4132-bf67-e96037f4813d")

               });
            modelBuilder.Entity<KursnaLista>()
               .HasData(new
               {
                   KursnaListaID = Guid.Parse("4f5b6e9b-00ed-462e-a451-7f233f9f5bb0"),
                   datum = DateTime.Parse("2021-2-19"),
                   valuta = "Euro",
                   vrednost = "117"
                   

               });
            modelBuilder.Entity<KursnaLista>()
               .HasData(new
               {
                   KursnaListaID = Guid.Parse("7fa35a46-23e8-41e1-8161-dc706ffc48c8"),
                   datum = DateTime.Parse("2021-2-19"),
                   valuta = "Dolar",
                   vrednost = "100"


               });
        }
    }
}
