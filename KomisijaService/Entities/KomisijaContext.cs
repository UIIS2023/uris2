using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KomisijaService.Entities
{
    public class KomisijaContext : DbContext
    {
        private readonly IConfiguration configuration;

        public KomisijaContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<Komisija> Komisija { get; set; }
        public DbSet<Predsednik> Predsednik { get; set; }
        public DbSet<Clanovi> Clanovi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("komisijaDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Predsednik>()
                .HasData(new
                {
                    predsednikID = Guid.Parse("61ef85bf-765a-4a53-a50a-9d99255cdeaf")
                });
            modelBuilder.Entity<Predsednik>()
                .HasData(new
                {
                    predsednikID = Guid.Parse("ebfc69f7-8626-48c4-8c92-c06ca85cf7b1")
                });
            modelBuilder.Entity<Predsednik>()
                .HasData(new
                {
                    predsednikID = Guid.Parse("efcbf7d7-de6b-4468-a8f7-d3907d541262")
                });
            modelBuilder.Entity<Komisija>()
                .HasData(new
                {
                    komisijaID = Guid.Parse("c1b8a40c-0e1c-44a6-87d2-1593ab638e94"),
                    predsednikID = Guid.Parse("61ef85bf-765a-4a53-a50a-9d99255cdeaf")
                });
            modelBuilder.Entity<Komisija>()
                .HasData(new
                {
                    komisijaID = Guid.Parse("0648b913-c49e-4939-95ae-10185e475ef7"),
                    predsednikID = Guid.Parse("efcbf7d7-de6b-4468-a8f7-d3907d541262")
                });
            modelBuilder.Entity<Komisija>()
                .HasData(new
                {
                    komisijaID = Guid.Parse("bf1c58fd-ba25-4bd9-837a-37c06ad29ea5"),
                    predsednikID = Guid.Parse("ebfc69f7-8626-48c4-8c92-c06ca85cf7b1")
                });
            modelBuilder.Entity<Clanovi>()
                .HasData(new
                {
                    clanoviID = Guid.Parse("ea3d75d9-61aa-4cc5-9e2a-6f01190b9044"),
                    komisijaID = Guid.Parse("c1b8a40c-0e1c-44a6-87d2-1593ab638e94")
                });
            modelBuilder.Entity<Clanovi>()
                 .HasData(new
                 {
                     clanoviID = Guid.Parse("c84a7948-81c5-44d2-86c1-c601fdab526b"),
                     komisijaID = Guid.Parse("0648b913-c49e-4939-95ae-10185e475ef7")
                 });
            modelBuilder.Entity<Clanovi>()
                 .HasData(new
                {
                    clanoviID = Guid.Parse("06cfa3e0-6d39-46c6-b5bb-98e0a64a9637"),
                    komisijaID = Guid.Parse("bf1c58fd-ba25-4bd9-837a-37c06ad29ea5")
                });
        }
    }
}
