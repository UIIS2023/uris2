using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using UgovorZakupService.DtoModels;

namespace UgovorZakupService.Entities
{
    public class UgovorOZakupuContext : DbContext
    {
        private readonly IConfiguration configuration;

        public UgovorOZakupuContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<UgovorOZakupu> ugovoriOZakupu { get; set; }
        public DbSet<TipGarancije> tipoviGarancije { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ugovorOZakupuDB"));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipGarancije>()
                .HasData(new
                {
                    tipGarancijeID = Guid.Parse("{1AE2154E-70F4-4621-855B-A56DF534F019}"),
                    nazivTipaGarancije = "Tip 1"
                });
            modelBuilder.Entity<TipGarancije>()
                .HasData(new
                {
                    tipGarancijeID = Guid.Parse("{CA93A3DB-F1C3-40C8-92D7-A6EA3790CFED}"),
                    nazivTipaGarancije = "Tip 2"
                });
            modelBuilder.Entity<UgovorOZakupu>()
                .HasData(new
                {
                    ugovorOZakupuID = Guid.Parse("{77647F87-7FF4-4722-A02B-4D34F3D8836F}"),
                    javnoNadmetanjeID = Guid.Parse("{1E412998-875C-4E53-9845-F853F42F80B2}"),
                    dokumentID = Guid.Parse("{566E5F3E-616C-4CCE-928F-9A85F12CD856}"),
                    tipGarancijeID = Guid.Parse("{70760F84-4571-4D15-B6C5-BC90A0E83855}"),
                    kupacID = Guid.Parse("{10051EAB-B9AC-467A-933B-2C1D82975137}"),
                    rokoviDospeca = new int[] { 1, 2, 3 },
                    zavodniBroj = "test zavodni broj",
                    datumZavodjenja = DateTime.Parse("2022-12-12"),
                    licnostID = Guid.Parse("{A5B356FD-99A2-435B-B3D5-87DA7C5F9A7F}"),
                    rokVracanjeZemljista = DateTime.Parse("2022-12-12"),
                    mestoPotpisivanja = "test mesto potpisivanja",
                    datumPotpisa = DateTime.Parse("2022-12-12")
                });
            modelBuilder.Entity<UgovorOZakupu>()
                .HasData(new
                {
                    ugovorOZakupuID = Guid.Parse("{36721EEC-7775-4FDE-B11E-1BC287B1ACCD}"),
                    javnoNadmetanjeID = Guid.Parse("{040F7BB0-8C60-4C11-9FD1-F7A05A9EB7E6}"),
                    dokumentID = Guid.Parse("{3B468A72-621E-4F1E-8FA7-DA06FD28427C}"),
                    tipGarancijeID = Guid.Parse("{F21636A8-639A-4922-82F8-40A6C8FAB202}"),
                    kupacID = Guid.Parse("{B62AFC63-812F-4A4D-BA6D-AF57FC7C5882}"),
                    rokoviDospeca = new int[] { 1, 2, 3 },
                    zavodniBroj = "test zavodni broj",
                    datumZavodjenja = DateTime.Parse("2022-12-12"),
                    licnostID = Guid.Parse("{088527CF-20D1-4F47-8F57-66B68DED5639}"),
                    rokVracanjeZemljista = DateTime.Parse("2022-12-12"),
                    mestoPotpisivanja = "test mesto potpisivanja",
                    datumPotpisa = DateTime.Parse("2022-12-12")
                });
        }
    }
}

