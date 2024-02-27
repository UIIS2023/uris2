using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AuctionService.Migrations
{
    /// <inheritdoc />
    public partial class migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "javnaNadmetanja",
                columns: table => new
                {
                    javnoNadmetanjeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vremePocetka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vremeKraja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pocetnaCenaPoHektaru = table.Column<int>(type: "int", nullable: false),
                    izuzeto = table.Column<bool>(type: "bit", nullable: false),
                    tipID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    izlicitiranaCena = table.Column<int>(type: "int", nullable: false),
                    periodZakupa = table.Column<int>(type: "int", nullable: false),
                    brojUcesnika = table.Column<int>(type: "int", nullable: false),
                    visinaDopuneDepozita = table.Column<int>(type: "int", nullable: false),
                    krug = table.Column<int>(type: "int", nullable: false),
                    statusNadmetanjaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    adresaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ovlascenoLiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    najboljiPonudjacID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_javnaNadmetanja", x => x.javnoNadmetanjeID);
                });

            migrationBuilder.CreateTable(
                name: "licitacije",
                columns: table => new
                {
                    licitacijaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    broj = table.Column<int>(type: "int", nullable: false),
                    godina = table.Column<int>(type: "int", nullable: false),
                    datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ogranicenja = table.Column<int>(type: "int", nullable: false),
                    korakCene = table.Column<int>(type: "int", nullable: false),
                    javnoNadmetanjeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    rokZaDostavljanje = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_licitacije", x => x.licitacijaID);
                });

            migrationBuilder.CreateTable(
                name: "statusiNadmetanja",
                columns: table => new
                {
                    statusNadmetanjaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statusiNadmetanja", x => x.statusNadmetanjaID);
                });

            migrationBuilder.CreateTable(
                name: "tipoviNadmetanja",
                columns: table => new
                {
                    tipJavnogNadmetanjaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nazivTipa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoviNadmetanja", x => x.tipJavnogNadmetanjaID);
                });

            migrationBuilder.InsertData(
                table: "javnaNadmetanja",
                columns: new[] { "javnoNadmetanjeID", "adresaID", "brojUcesnika", "datum", "izlicitiranaCena", "izuzeto", "krug", "najboljiPonudjacID", "ovlascenoLiceID", "periodZakupa", "pocetnaCenaPoHektaru", "statusNadmetanjaID", "tipID", "visinaDopuneDepozita", "vremeKraja", "vremePocetka" },
                values: new object[,]
                {
                    { new Guid("13d6ced2-ab84-4132-bf67-e96037f4813d"), new Guid("a06f99d2-0ba7-40ff-a241-304a03dfe4be"), 10, new DateTime(2022, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 6000, false, 1, new Guid("8b3b7775-4293-4b41-9ccc-19f9cf694d68"), new Guid("5cfa282f-8324-4a8b-8c23-8d43502ca01e"), 12, 4000, new Guid("8aaa90c8-56f3-4a76-b07a-f895eded5a84"), new Guid("4246a611-7b2f-429d-a9ba-0e539c81b82f"), 400, new DateTime(2022, 2, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 18, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("208a48a5-371c-4f9d-ac23-18bb176ff8f3"), new Guid("a06f99d2-0ba7-40ff-a241-304a03dfe4be"), 10, new DateTime(2022, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 7500, false, 1, new Guid("8b3b7775-4293-4b41-9ccc-19f9cf694d68"), new Guid("5cfa282f-8324-4a8b-8c23-8d43502ca01e"), 12, 5000, new Guid("8aaa90c8-56f3-4a76-b07a-f895eded5a84"), new Guid("4246a611-7b2f-429d-a9ba-0e539c81b82f"), 500, new DateTime(2022, 2, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 17, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "licitacije",
                columns: new[] { "licitacijaID", "broj", "datum", "godina", "javnoNadmetanjeId", "korakCene", "ogranicenja", "rokZaDostavljanje" },
                values: new object[,]
                {
                    { new Guid("1de13266-85e8-4120-8b1f-daacc32c5811"), 2, new DateTime(2022, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2022, new Guid("208a48a5-371c-4f9d-ac23-18bb176ff8f3"), 200, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a215e4cb-a427-40cf-88b2-8488d140a939"), 1, new DateTime(2022, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2022, new Guid("208a48a5-371c-4f9d-ac23-18bb176ff8f3"), 100, 1, new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "statusiNadmetanja",
                columns: new[] { "statusNadmetanjaID", "naziv" },
                values: new object[,]
                {
                    { new Guid("8aaa90c8-56f3-4a76-b07a-f895eded5a84"), "Prvi krug" },
                    { new Guid("b1ad846b-f76f-4485-8c89-08e2dfebd112"), "Drugi krug sa starim uslovima" },
                    { new Guid("d85b4a71-27e4-4626-9a3e-0412430e03d6"), "Drugi krug sa novim uslovima" }
                });

            migrationBuilder.InsertData(
                table: "tipoviNadmetanja",
                columns: new[] { "tipJavnogNadmetanjaID", "nazivTipa" },
                values: new object[,]
                {
                    { new Guid("4246a611-7b2f-429d-a9ba-0e539c81b82f"), "Javna licitacija" },
                    { new Guid("99b6d6ec-4358-4898-936b-31b31d236324"), "Otvaranje zatvorenih ponuda" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "javnaNadmetanja");

            migrationBuilder.DropTable(
                name: "licitacije");

            migrationBuilder.DropTable(
                name: "statusiNadmetanja");

            migrationBuilder.DropTable(
                name: "tipoviNadmetanja");
        }
    }
}
