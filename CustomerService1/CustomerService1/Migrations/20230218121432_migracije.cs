using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CustomerService1.Migrations
{
    /// <inheritdoc />
    public partial class migracije : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kontaktOsoba",
                columns: table => new
                {
                    KontaktOsobaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Funkcija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kontaktOsoba", x => x.KontaktOsobaID);
                });

            migrationBuilder.CreateTable(
                name: "kupci",
                columns: table => new
                {
                    KupacID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FizPravno = table.Column<bool>(type: "bit", nullable: false),
                    OstvarenaPovrsina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zabrana = table.Column<bool>(type: "bit", nullable: false),
                    PocetakZabrane = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuzinaZabrane = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrestanakZabrane = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OvlascenoLiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PrioritetID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrTel1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrTel2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UplataID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojRacuna = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kupci", x => x.KupacID);
                });

            migrationBuilder.CreateTable(
                name: "prioriteti",
                columns: table => new
                {
                    PrioritetID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OpisPrioriteta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prioriteti", x => x.PrioritetID);
                });

            migrationBuilder.InsertData(
                table: "kontaktOsoba",
                columns: new[] { "KontaktOsobaID", "Funkcija", "Ime", "Prezime", "Telefon" },
                values: new object[,]
                {
                    { new Guid("2d5cacd8-81da-4e11-b483-4a32a7ea6085"), "funkcija2", "Sandra", "Lazic", "0695476115" },
                    { new Guid("8685933f-8b02-450b-aa68-f040f2b0273e"), "funkcija1", "Nikola", "Popovic", "0678544256" }
                });

            migrationBuilder.InsertData(
                table: "kupci",
                columns: new[] { "KupacID", "AdresaID", "BrTel1", "BrTel2", "BrojRacuna", "DuzinaZabrane", "Email", "FizPravno", "OstvarenaPovrsina", "OvlascenoLiceID", "PocetakZabrane", "PrestanakZabrane", "PrioritetID", "UplataID", "Zabrana" },
                values: new object[,]
                {
                    { new Guid("208a48a5-371c-4f9d-ac23-18bb176ff8f3"), new Guid("778c3ad6-84f9-48ef-a00f-ea109a46a724"), "0654811935", "5684951", "56449851", "1 godina", "sanja00@gmal.com", true, "250", new Guid("e6721431-2b48-442a-a93e-24d8d7c4ef22"), new DateTime(2021, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f9a334b1-d69a-4f9d-a7b6-5d22ae04248a"), new Guid("1f573635-14e0-4211-81fb-ae4211ec3bdb"), true },
                    { new Guid("f352f125-4e69-4cfc-a297-f15e16f14df3"), new Guid("c30f6f67-0c74-4165-83bb-2b9525882efb"), "0606499581", "459667", "16599874", "1 godina", "asavic@gmal.com", true, "200", new Guid("574fd280-fdf3-44e2-bf0a-addfb4c9be53"), new DateTime(2021, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b604c2f3-3653-4c55-8555-d3fe41bbae01"), new Guid("834a56c9-7f9c-46e8-9fac-6345948ba0db"), true }
                });

            migrationBuilder.InsertData(
                table: "prioriteti",
                columns: new[] { "PrioritetID", "OpisPrioriteta" },
                values: new object[,]
                {
                    { new Guid("33b1ea56-ef1a-4608-a0a4-6d5fcbdbf7c1"), " Vlasnik zemljista koji je najblize zemljistu koje se daje u zakup" },
                    { new Guid("87fc1ead-7d94-4d76-b72f-7c340bb73ca7"), " Poljuprivrednik koji je upisan u registar" },
                    { new Guid("b604c2f3-3653-4c55-8555-d3fe41bbae01"), " Vlasnik zemljišta koje se graniči sa zemljištem koje se daje u zakup" },
                    { new Guid("f9a334b1-d69a-4f9d-a7b6-5d22ae04248a"), "Vlasnik sistema za navodnjavanje" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kontaktOsoba");

            migrationBuilder.DropTable(
                name: "kupci");

            migrationBuilder.DropTable(
                name: "prioriteti");
        }
    }
}
