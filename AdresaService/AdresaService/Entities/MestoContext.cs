using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaService.Entities
{
    public class MestoContext : DbContext
    {
        private readonly IConfiguration configuration;
        public MestoContext(DbContextOptions<MestoContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }
        public DbSet<Adresa> Adresa { get; set; }
        public DbSet<Drzava> Drzava { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MestoDB"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adresa>()
                .HasData(
                new Adresa
                {
                    AdresaId = Guid.Parse("a06f99d2-0ba7-40ff-a241-304a03dfe4be"),
                    Mesto = "SM",
                    PostanskiBroj = 2200,
                    Ulica = "SAve kovacevica 25"
                }
                );
            modelBuilder.Entity<Drzava>()
                .HasData(
                new Drzava
                {
                    DrzavaId = Guid.Parse("24742b99-32c6-4999-b0a7-757a178f9ee7"),
                    Naziv = "Srbija"
                }
                );
        }
    }
}