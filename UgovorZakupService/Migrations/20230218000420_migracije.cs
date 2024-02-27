using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UgovorZakupService.Migrations
{
    /// <inheritdoc />
    public partial class migracije : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tipoviGarancije",
                columns: table => new
                {
                    tipGarancijeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nazivTipaGarancije = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoviGarancije", x => x.tipGarancijeID);
                });

            migrationBuilder.CreateTable(
                name: "ugovoriOZakupu",
                columns: table => new
                {
                    ugovorOZakupuID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    javnoNadmetanjeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dokumentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tipGarancijeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    kupacID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    zavodniBroj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datumZavodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    licnostID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    rokVracanjeZemljista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    mestoPotpisivanja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datumPotpisa = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ugovoriOZakupu", x => x.ugovorOZakupuID);
                });

            migrationBuilder.InsertData(
                table: "tipoviGarancije",
                columns: new[] { "tipGarancijeID", "nazivTipaGarancije" },
                values: new object[,]
                {
                    { new Guid("1ae2154e-70f4-4621-855b-a56df534f019"), "Tip 1" },
                    { new Guid("ca93a3db-f1c3-40c8-92d7-a6ea3790cfed"), "Tip 2" }
                });

            migrationBuilder.InsertData(
                table: "ugovoriOZakupu",
                columns: new[] { "ugovorOZakupuID", "datumPotpisa", "datumZavodjenja", "dokumentID", "javnoNadmetanjeID", "kupacID", "licnostID", "mestoPotpisivanja", "rokVracanjeZemljista", "tipGarancijeID", "zavodniBroj" },
                values: new object[,]
                {
                    { new Guid("36721eec-7775-4fde-b11e-1bc287b1accd"), new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3b468a72-621e-4f1e-8fa7-da06fd28427c"), new Guid("040f7bb0-8c60-4c11-9fd1-f7a05a9eb7e6"), new Guid("b62afc63-812f-4a4d-ba6d-af57fc7c5882"), new Guid("088527cf-20d1-4f47-8f57-66b68ded5639"), "test mesto potpisivanja", new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f21636a8-639a-4922-82f8-40a6c8fab202"), "test zavodni broj" },
                    { new Guid("77647f87-7ff4-4722-a02b-4d34f3d8836f"), new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("566e5f3e-616c-4cce-928f-9a85f12cd856"), new Guid("1e412998-875c-4e53-9845-f853f42f80b2"), new Guid("10051eab-b9ac-467a-933b-2c1d82975137"), new Guid("a5b356fd-99a2-435b-b3d5-87da7c5f9a7f"), "test mesto potpisivanja", new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("70760f84-4571-4d15-b6c5-bc90a0e83855"), "test zavodni broj" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tipoviGarancije");

            migrationBuilder.DropTable(
                name: "ugovoriOZakupu");
        }
    }
}
