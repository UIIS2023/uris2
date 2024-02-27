using Dokumenti_Service.Entities.Dokument;
using Dokumenti_Service.Entities.Oglas;
using Dokumenti_Service.Entities.Zalba;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;


namespace Dokumenti_Service.Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Dokument.Dokument> Dokument { get; set; }
        public DbSet<Dokument.Status> Status { get; set; }
        public DbSet<Oglas.Oglas> Oglas { get; set; }
        public DbSet<Oglas.OglasnaTabla> OglasnaTabla { get; set; }
        public DbSet<Oglas.OglasnaTablaOglas> OglasnaTablaOglas { get; set; }
        public DbSet<Zalba.Zalba> Zalba { get; set; }
        public DbSet<Zalba.TipZalbe> TipZalbe { get; set; }
        public DbSet<Zalba.RadnjaNaOsnovuZalbe> Radnja { get; set; }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OglasnaTablaOglas>()
                .HasKey(og => new { og.oglasId, og.oglasnaTablaId });
            builder.Entity<OglasnaTablaOglas>()
                .HasOne(p => p.Oglas)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(p => p.oglasId);

            builder.Entity<OglasnaTablaOglas>()
                .HasOne(p => p.OglasnaTabla)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(p => p.oglasnaTablaId);
            builder.Entity<Status>().HasData(new
            {
                statusID = Guid.Parse("c61515cf-2210-4358-bcd7-c900b0d52fa7"),
                status ="aktivan"
                
            });
            builder.Entity<Dokument.Dokument>().HasData(new
            {
                dokumentId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3975a3"),
                zavodniBroj = "1",
                datumDokumenta = DateTime.Parse("2022-12-20T10:00:00"),
                datumKreiranjaDokumenta = DateTime.Parse("2022-10-11T12:00:00"),
                sablon = "7b",
                dokumentStatusID = Guid.Parse("c61515cf-2210-4358-bcd7-c900b0d52fa7")
            });
            builder.Entity<OglasnaTabla>().HasData(new
            {
                oglasnaTablaId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c397475"),
                BrojOglasneTable = 12,
                DatumObjavljivanja= DateTime.Parse("2020-11-15T09:00:00")

            });
            builder.Entity<Oglas.Oglas>().HasData(new
            {
                oglasId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c397444"),
                tekstOglasa = "Javni oglas za davanje u zakup poljoprivrednog zemljišta u državnoj svojini",
                oglasnaTablaId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c397475"),
                dokumentId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3975a3")
            });
            builder.Entity<TipZalbe>()
                .HasData(new
                {
                    tipZalbeId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                    tipZalbe = "Zalba na tok javnog nadmetanja"
                });

            builder.Entity<TipZalbe>()
                .HasData(new
                {
                    tipZalbeId = Guid.Parse("1c7ea607-8ddb-493a-87fa-4bf5893e965b"),
                    tipZalbe = "Zalba na Odluku o davanju u zakup"
                });

            
         
            builder.Entity<RadnjaNaOsnovuZalbe>()
                .HasData(new
                {
                    radnjaNaOsnovuZalbeId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                    radnjaNaOsnovuZalbe = "JN ide u drugi krug sa novim uslovima"
                });
            builder.Entity<Zalba.Zalba>()
               .HasData(new
               {
                   zalbaId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                   razlog = "Dokumenti nisu evidentirani validno",
                   datumPodnosenja = DateTime.Parse("2022-11-20T10:06:00"),
                   obrazlozenje = "Smatramo da dokumenti koje smo predali nisu evidentirani adekvatno",
                   statusZalbe="pregledana",
                   brojOdluke = "27c" ,
                   brojResenja = "1a",
                   radnjaNaOsnovuZalbeId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                   tipZalbeID = Guid.Parse("1c7ea607-8ddb-493a-87fa-4bf5893e965b")


               });
        }
    }
}
