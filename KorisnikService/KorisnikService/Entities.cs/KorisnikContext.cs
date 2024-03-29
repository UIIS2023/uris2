﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using KorisnikService.Entities;

namespace KorisnikService.Entities
{
    public class KorisnikContext : DbContext
    {
        
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<TipKorisnika> TipKorisnika { get; set; }

        public KorisnikContext(DbContextOptions options) : base(options)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Korisnik>()
                .HasData(
                new Korisnik
                {
                    korisnikId = Guid.Parse("f7a20259-5aeb-3135-64ea-32cf7a96b98a"),
                    tipKorisnikaId = Guid.Parse("ce4a6a8a-b25d-d5d0-9364-3dee56521821"),
                    ime = "Petar",
                    prezime = "Petrovic",
                    korisnickoIme = "PPetrovic",
                    lozinka = "123456"
                },
                new Korisnik
                {
                    korisnikId = Guid.Parse("e8920f41-e035-da6d-27d1-ee8909f6271d"),
                    tipKorisnikaId = Guid.Parse("22caf793-fbaa-a3f5-8266-7fc3dcc798dc"),
                    ime = "Marko",
                    prezime = "Markovic",
                    korisnickoIme = "MMarkovic",
                    lozinka = "123456"
                }
                );
            modelBuilder.Entity<TipKorisnika>()
                .HasData(
                new TipKorisnika
                {
                    tipKorisnikaId = Guid.Parse("9d8004cb-fad6-40a9-9d9e-978ff4f98481"),
                    uloga = "Admin"
                }
                );
        }
    }
}
