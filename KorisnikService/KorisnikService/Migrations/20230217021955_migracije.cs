using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KorisnikService.Migrations
{
    /// <inheritdoc />
    public partial class migracije : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    korisnikId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tipKorisnikaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    korisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.korisnikId);
                });

            migrationBuilder.CreateTable(
                name: "TipKorisnika",
                columns: table => new
                {
                    tipKorisnikaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    uloga = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipKorisnika", x => x.tipKorisnikaId);
                });

            migrationBuilder.InsertData(
                table: "Korisnik",
                columns: new[] { "korisnikId", "ime", "korisnickoIme", "lozinka", "prezime", "tipKorisnikaId" },
                values: new object[,]
                {
                    { new Guid("e8920f41-e035-da6d-27d1-ee8909f6271d"), "Marko", "MMarkovic", "123456", "Markovic", new Guid("22caf793-fbaa-a3f5-8266-7fc3dcc798dc") },
                    { new Guid("f7a20259-5aeb-3135-64ea-32cf7a96b98a"), "Petar", "PPetrovic", "123456", "Petrovic", new Guid("ce4a6a8a-b25d-d5d0-9364-3dee56521821") }
                });

            migrationBuilder.InsertData(
                table: "TipKorisnika",
                columns: new[] { "tipKorisnikaId", "uloga" },
                values: new object[] { new Guid("9d8004cb-fad6-40a9-9d9e-978ff4f98481"), "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "TipKorisnika");
        }
    }
}
