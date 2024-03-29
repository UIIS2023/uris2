﻿// <auto-generated />
using System;
using CustomerService1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerService1.Migrations
{
    [DbContext(typeof(KupacContext))]
    [Migration("20230218121432_migracije")]
    partial class migracije
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerService1.Entities.KontaktOsoba", b =>
                {
                    b.Property<Guid>("KontaktOsobaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Funkcija")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KontaktOsobaID");

                    b.ToTable("kontaktOsoba");

                    b.HasData(
                        new
                        {
                            KontaktOsobaID = new Guid("8685933f-8b02-450b-aa68-f040f2b0273e"),
                            Funkcija = "funkcija1",
                            Ime = "Nikola",
                            Prezime = "Popovic",
                            Telefon = "0678544256"
                        },
                        new
                        {
                            KontaktOsobaID = new Guid("2d5cacd8-81da-4e11-b483-4a32a7ea6085"),
                            Funkcija = "funkcija2",
                            Ime = "Sandra",
                            Prezime = "Lazic",
                            Telefon = "0695476115"
                        });
                });

            modelBuilder.Entity("CustomerService1.Entities.Kupac", b =>
                {
                    b.Property<Guid>("KupacID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdresaID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrTel1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrTel2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojRacuna")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DuzinaZabrane")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("FizPravno")
                        .HasColumnType("bit");

                    b.Property<string>("OstvarenaPovrsina")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OvlascenoLiceID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("PocetakZabrane")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PrestanakZabrane")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PrioritetID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UplataID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Zabrana")
                        .HasColumnType("bit");

                    b.HasKey("KupacID");

                    b.ToTable("kupci");

                    b.HasData(
                        new
                        {
                            KupacID = new Guid("208a48a5-371c-4f9d-ac23-18bb176ff8f3"),
                            AdresaID = new Guid("778c3ad6-84f9-48ef-a00f-ea109a46a724"),
                            BrTel1 = "0654811935",
                            BrTel2 = "5684951",
                            BrojRacuna = "56449851",
                            DuzinaZabrane = "1 godina",
                            Email = "sanja00@gmal.com",
                            FizPravno = true,
                            OstvarenaPovrsina = "250",
                            OvlascenoLiceID = new Guid("e6721431-2b48-442a-a93e-24d8d7c4ef22"),
                            PocetakZabrane = new DateTime(2021, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PrestanakZabrane = new DateTime(2022, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PrioritetID = new Guid("f9a334b1-d69a-4f9d-a7b6-5d22ae04248a"),
                            UplataID = new Guid("1f573635-14e0-4211-81fb-ae4211ec3bdb"),
                            Zabrana = true
                        },
                        new
                        {
                            KupacID = new Guid("f352f125-4e69-4cfc-a297-f15e16f14df3"),
                            AdresaID = new Guid("c30f6f67-0c74-4165-83bb-2b9525882efb"),
                            BrTel1 = "0606499581",
                            BrTel2 = "459667",
                            BrojRacuna = "16599874",
                            DuzinaZabrane = "1 godina",
                            Email = "asavic@gmal.com",
                            FizPravno = true,
                            OstvarenaPovrsina = "200",
                            OvlascenoLiceID = new Guid("574fd280-fdf3-44e2-bf0a-addfb4c9be53"),
                            PocetakZabrane = new DateTime(2021, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PrestanakZabrane = new DateTime(2022, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PrioritetID = new Guid("b604c2f3-3653-4c55-8555-d3fe41bbae01"),
                            UplataID = new Guid("834a56c9-7f9c-46e8-9fac-6345948ba0db"),
                            Zabrana = true
                        });
                });

            modelBuilder.Entity("CustomerService1.Entities.Prioritet", b =>
                {
                    b.Property<Guid>("PrioritetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OpisPrioriteta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PrioritetID");

                    b.ToTable("prioriteti");

                    b.HasData(
                        new
                        {
                            PrioritetID = new Guid("f9a334b1-d69a-4f9d-a7b6-5d22ae04248a"),
                            OpisPrioriteta = "Vlasnik sistema za navodnjavanje"
                        },
                        new
                        {
                            PrioritetID = new Guid("b604c2f3-3653-4c55-8555-d3fe41bbae01"),
                            OpisPrioriteta = " Vlasnik zemljišta koje se graniči sa zemljištem koje se daje u zakup"
                        },
                        new
                        {
                            PrioritetID = new Guid("87fc1ead-7d94-4d76-b72f-7c340bb73ca7"),
                            OpisPrioriteta = " Poljuprivrednik koji je upisan u registar"
                        },
                        new
                        {
                            PrioritetID = new Guid("33b1ea56-ef1a-4608-a0a4-6d5fcbdbf7c1"),
                            OpisPrioriteta = " Vlasnik zemljista koji je najblize zemljistu koje se daje u zakup"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
