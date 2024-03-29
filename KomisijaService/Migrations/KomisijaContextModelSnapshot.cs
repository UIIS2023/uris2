﻿// <auto-generated />
using System;
using KomisijaService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KomisijaService.Migrations
{
    [DbContext(typeof(KomisijaContext))]
    partial class KomisijaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KomisijaService.Entities.Clanovi", b =>
                {
                    b.Property<Guid>("clanoviID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("komisijaID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("clanoviID");

                    b.ToTable("Clanovi");

                    b.HasData(
                        new
                        {
                            clanoviID = new Guid("ea3d75d9-61aa-4cc5-9e2a-6f01190b9044"),
                            komisijaID = new Guid("c1b8a40c-0e1c-44a6-87d2-1593ab638e94")
                        },
                        new
                        {
                            clanoviID = new Guid("c84a7948-81c5-44d2-86c1-c601fdab526b"),
                            komisijaID = new Guid("0648b913-c49e-4939-95ae-10185e475ef7")
                        },
                        new
                        {
                            clanoviID = new Guid("06cfa3e0-6d39-46c6-b5bb-98e0a64a9637"),
                            komisijaID = new Guid("bf1c58fd-ba25-4bd9-837a-37c06ad29ea5")
                        });
                });

            modelBuilder.Entity("KomisijaService.Entities.Komisija", b =>
                {
                    b.Property<Guid>("komisijaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("predsednikID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("komisijaID");

                    b.ToTable("Komisija");

                    b.HasData(
                        new
                        {
                            komisijaID = new Guid("c1b8a40c-0e1c-44a6-87d2-1593ab638e94"),
                            predsednikID = new Guid("61ef85bf-765a-4a53-a50a-9d99255cdeaf")
                        },
                        new
                        {
                            komisijaID = new Guid("0648b913-c49e-4939-95ae-10185e475ef7"),
                            predsednikID = new Guid("efcbf7d7-de6b-4468-a8f7-d3907d541262")
                        },
                        new
                        {
                            komisijaID = new Guid("bf1c58fd-ba25-4bd9-837a-37c06ad29ea5"),
                            predsednikID = new Guid("ebfc69f7-8626-48c4-8c92-c06ca85cf7b1")
                        });
                });

            modelBuilder.Entity("KomisijaService.Entities.Predsednik", b =>
                {
                    b.Property<Guid>("predsednikID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("predsednikID");

                    b.ToTable("Predsednik");

                    b.HasData(
                        new
                        {
                            predsednikID = new Guid("61ef85bf-765a-4a53-a50a-9d99255cdeaf")
                        },
                        new
                        {
                            predsednikID = new Guid("ebfc69f7-8626-48c4-8c92-c06ca85cf7b1")
                        },
                        new
                        {
                            predsednikID = new Guid("efcbf7d7-de6b-4468-a8f7-d3907d541262")
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
