using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dokumenti_Service.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dokument",
                columns: table => new
                {
                    dokumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    zavodniBroj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datumKreiranjaDokumenta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    datumDokumenta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    sablon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dokumentStatusID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokument", x => x.dokumentId);
                });

            migrationBuilder.CreateTable(
                name: "OglasnaTabla",
                columns: table => new
                {
                    oglasnaTablaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrojOglasneTable = table.Column<int>(type: "int", nullable: false),
                    DatumObjavljivanja = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OglasnaTabla", x => x.oglasnaTablaId);
                });

            migrationBuilder.CreateTable(
                name: "Radnja",
                columns: table => new
                {
                    radnjaNaOsnovuZalbeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    radnjaNaOsnovuZalbe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radnja", x => x.radnjaNaOsnovuZalbeId);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    statusID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.statusID);
                });

            migrationBuilder.CreateTable(
                name: "TipZalbe",
                columns: table => new
                {
                    tipZalbeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tipZalbe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipZalbe", x => x.tipZalbeId);
                });

            migrationBuilder.CreateTable(
                name: "Oglas",
                columns: table => new
                {
                    oglasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tekstOglasa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    oglasnaTablaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dokumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oglas", x => x.oglasId);
                    table.ForeignKey(
                        name: "FK_Oglas_Dokument_dokumentId",
                        column: x => x.dokumentId,
                        principalTable: "Dokument",
                        principalColumn: "dokumentId");
                    table.ForeignKey(
                        name: "FK_Oglas_OglasnaTabla_oglasnaTablaId",
                        column: x => x.oglasnaTablaId,
                        principalTable: "OglasnaTabla",
                        principalColumn: "oglasnaTablaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zalba",
                columns: table => new
                {
                    zalbaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    datumPodnosenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    razlog = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    obrazlozenje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brojOdluke = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brojResenja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipZalbeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    statusZalbe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    radnjaNaOsnovuZalbeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KupacID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    dokumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zalba", x => x.zalbaId);
                    table.ForeignKey(
                        name: "FK_Zalba_Dokument_dokumentId",
                        column: x => x.dokumentId,
                        principalTable: "Dokument",
                        principalColumn: "dokumentId");
                    table.ForeignKey(
                        name: "FK_Zalba_Radnja_radnjaNaOsnovuZalbeId",
                        column: x => x.radnjaNaOsnovuZalbeId,
                        principalTable: "Radnja",
                        principalColumn: "radnjaNaOsnovuZalbeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zalba_TipZalbe_tipZalbeID",
                        column: x => x.tipZalbeID,
                        principalTable: "TipZalbe",
                        principalColumn: "tipZalbeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OglasnaTablaOglas",
                columns: table => new
                {
                    oglasnaTablaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    oglasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OglasnaTablaOglas", x => new { x.oglasId, x.oglasnaTablaId });
                    table.ForeignKey(
                        name: "FK_OglasnaTablaOglas_Oglas_oglasId",
                        column: x => x.oglasId,
                        principalTable: "Oglas",
                        principalColumn: "oglasId");
                    table.ForeignKey(
                        name: "FK_OglasnaTablaOglas_OglasnaTabla_oglasnaTablaId",
                        column: x => x.oglasnaTablaId,
                        principalTable: "OglasnaTabla",
                        principalColumn: "oglasnaTablaId");
                });

            migrationBuilder.InsertData(
                table: "Dokument",
                columns: new[] { "dokumentId", "datumDokumenta", "datumKreiranjaDokumenta", "dokumentStatusID", "sablon", "zavodniBroj" },
                values: new object[] { new Guid("6a411c13-a195-48f7-8dbd-67596c3975a3"), new DateTime(2022, 12, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 11, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c61515cf-2210-4358-bcd7-c900b0d52fa7"), "7b", "1" });

            migrationBuilder.InsertData(
                table: "OglasnaTabla",
                columns: new[] { "oglasnaTablaId", "BrojOglasneTable", "DatumObjavljivanja" },
                values: new object[] { new Guid("6a411c13-a195-48f7-8dbd-67596c397475"), 12, new DateTime(2020, 11, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Radnja",
                columns: new[] { "radnjaNaOsnovuZalbeId", "radnjaNaOsnovuZalbe" },
                values: new object[] { new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), "JN ide u drugi krug sa novim uslovima" });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "statusID", "status" },
                values: new object[] { new Guid("c61515cf-2210-4358-bcd7-c900b0d52fa7"), "aktivan" });

            migrationBuilder.InsertData(
                table: "TipZalbe",
                columns: new[] { "tipZalbeId", "tipZalbe" },
                values: new object[,]
                {
                    { new Guid("1c7ea607-8ddb-493a-87fa-4bf5893e965b"), "Zalba na Odluku o davanju u zakup" },
                    { new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), "Zalba na tok javnog nadmetanja" }
                });

            migrationBuilder.InsertData(
                table: "Oglas",
                columns: new[] { "oglasId", "dokumentId", "oglasnaTablaId", "tekstOglasa" },
                values: new object[] { new Guid("6a411c13-a195-48f7-8dbd-67596c397444"), new Guid("6a411c13-a195-48f7-8dbd-67596c3975a3"), new Guid("6a411c13-a195-48f7-8dbd-67596c397475"), "Javni oglas za davanje u zakup poljoprivrednog zemljišta u državnoj svojini" });

            migrationBuilder.InsertData(
                table: "Zalba",
                columns: new[] { "zalbaId", "KupacID", "brojOdluke", "brojResenja", "datumPodnosenja", "dokumentId", "obrazlozenje", "radnjaNaOsnovuZalbeId", "razlog", "statusZalbe", "tipZalbeID" },
                values: new object[] { new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), null, "27c", "1a", new DateTime(2022, 11, 20, 10, 6, 0, 0, DateTimeKind.Unspecified), null, "Smatramo da dokumenti koje smo predali nisu evidentirani adekvatno", new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), "Dokumenti nisu evidentirani validno", "pregledana", new Guid("1c7ea607-8ddb-493a-87fa-4bf5893e965b") });

            migrationBuilder.CreateIndex(
                name: "IX_Oglas_dokumentId",
                table: "Oglas",
                column: "dokumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Oglas_oglasnaTablaId",
                table: "Oglas",
                column: "oglasnaTablaId");

            migrationBuilder.CreateIndex(
                name: "IX_OglasnaTablaOglas_oglasnaTablaId",
                table: "OglasnaTablaOglas",
                column: "oglasnaTablaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zalba_dokumentId",
                table: "Zalba",
                column: "dokumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Zalba_radnjaNaOsnovuZalbeId",
                table: "Zalba",
                column: "radnjaNaOsnovuZalbeId");

            migrationBuilder.CreateIndex(
                name: "IX_Zalba_tipZalbeID",
                table: "Zalba",
                column: "tipZalbeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OglasnaTablaOglas");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Zalba");

            migrationBuilder.DropTable(
                name: "Oglas");

            migrationBuilder.DropTable(
                name: "Radnja");

            migrationBuilder.DropTable(
                name: "TipZalbe");

            migrationBuilder.DropTable(
                name: "Dokument");

            migrationBuilder.DropTable(
                name: "OglasnaTabla");
        }
    }
}
