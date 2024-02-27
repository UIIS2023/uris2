using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServiceParcela.Migrations
{
    /// <inheritdoc />
    public partial class ParcelaContextMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "deloviParcele",
                columns: table => new
                {
                    deoParceleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    parcelaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idealniDeoParcele = table.Column<int>(type: "int", nullable: false),
                    stvarniDeoParcele = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deloviParcele", x => x.deoParceleID);
                });

            migrationBuilder.CreateTable(
                name: "katastarskeOpstine",
                columns: table => new
                {
                    katastarskaOpstinaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nazivKatastarskeOpstine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_katastarskeOpstine", x => x.katastarskaOpstinaID);
                });

            migrationBuilder.CreateTable(
                name: "klase",
                columns: table => new
                {
                    klasaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nazivKlase = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_klase", x => x.klasaID);
                });

            migrationBuilder.CreateTable(
                name: "kulture",
                columns: table => new
                {
                    kulturaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nazivKulture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kulture", x => x.kulturaID);
                });

            migrationBuilder.CreateTable(
                name: "obliciSvojine",
                columns: table => new
                {
                    oblikSvojineID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nazivOblikaSvojine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_obliciSvojine", x => x.oblikSvojineID);
                });

            migrationBuilder.CreateTable(
                name: "obradivosti",
                columns: table => new
                {
                    obradivostID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nazivObradivosti = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_obradivosti", x => x.obradivostID);
                });

            migrationBuilder.CreateTable(
                name: "odvodnjavanja",
                columns: table => new
                {
                    odvodnjavanjeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nazivOdvodnjavanja = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_odvodnjavanja", x => x.odvodnjavanjeID);
                });

            migrationBuilder.CreateTable(
                name: "parcele",
                columns: table => new
                {
                    parcelaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    korisnikParceleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    povrsina = table.Column<int>(type: "int", nullable: false),
                    brojParcele = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    katastarskaOpstinaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    brojListaNepokretnosti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kulturaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    klasaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    obradivostID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    zasticenaZonaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    oblikSvojineID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    odvodnjavanjeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    obradivostStvarnoStanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kulturaStvarnoStanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    klasaStvarnoStanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    zasticenaZonaStvarnoStanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    odvodnjavanjeStvarnoStanje = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parcele", x => x.parcelaID);
                });

            migrationBuilder.CreateTable(
                name: "zasticeneZone",
                columns: table => new
                {
                    zasticenaZonaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nazivZasticeneZone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zasticeneZone", x => x.zasticenaZonaID);
                });

            migrationBuilder.InsertData(
                table: "deloviParcele",
                columns: new[] { "deoParceleID", "idealniDeoParcele", "parcelaID", "stvarniDeoParcele" },
                values: new object[,]
                {
                    { new Guid("5d5a016a-b9c8-4bcd-9824-eec0106b32a8"), 40, new Guid("b6194c5f-217a-40a4-99c2-5430096d02db"), 60 },
                    { new Guid("61d33f97-6b7e-4aa6-adc5-c307e0da50c3"), 55, new Guid("b6194c5f-217a-40a4-99c2-5430096d02db"), 45 }
                });

            migrationBuilder.InsertData(
                table: "katastarskeOpstine",
                columns: new[] { "katastarskaOpstinaID", "nazivKatastarskeOpstine" },
                values: new object[,]
                {
                    { new Guid("1a1de9ad-916b-4b43-adda-d5a1783c4a8d"), "Stari Grad" },
                    { new Guid("2a366ea1-1141-4d68-a544-3bbdcfb153ba"), "Žednik" },
                    { new Guid("3c13042d-4c28-470b-b512-b6d1bc2c343e"), "Tavankut" },
                    { new Guid("5c6c9e3b-ddba-4cf9-ae71-eceed1f41989"), "Novi Grad" },
                    { new Guid("807391fc-b3f1-4b69-a6a7-c48d54585387"), "Bikovo" },
                    { new Guid("9514b1b3-0d7a-49ae-80ba-46f9df420083"), "Đuđin" },
                    { new Guid("954d582c-134f-462e-b634-d4eb99d76369"), "Donji Grad" },
                    { new Guid("b41c324d-a885-46ce-93c6-2cf38df6c679"), "Čantavir" },
                    { new Guid("c1ef2536-0329-4cc9-b8a9-307e6a259471"), "Palić" },
                    { new Guid("c4e673a1-b52b-4f09-afe4-2d8cd0612ffa"), "Bački Vinogradi" },
                    { new Guid("d351326d-624e-454d-b459-e4b145a2b3c8"), "Bajmok" }
                });

            migrationBuilder.InsertData(
                table: "klase",
                columns: new[] { "klasaID", "nazivKlase" },
                values: new object[,]
                {
                    { new Guid("14791175-a1d8-4ce1-81ce-ab25bc9af38e"), "III" },
                    { new Guid("17a15c54-c4d3-40a1-b531-2b142aadb2c8"), "IV" },
                    { new Guid("459a1c86-2562-4599-a1ce-d5259c4a30db"), "VII" },
                    { new Guid("50bfacfe-4048-4bfe-ab1f-5beaeb33e01c"), "VIII" },
                    { new Guid("8adefb3d-8818-4c27-b6c2-276b4063d619"), "V" },
                    { new Guid("8b479542-bc13-4b6e-8139-f2dc2c47ae74"), "II" },
                    { new Guid("8ed8e0eb-fae8-4de9-9916-1e7f84625d2c"), "VI" },
                    { new Guid("ea46fc42-300c-42bd-85ec-b41864c5bfc8"), "I" }
                });

            migrationBuilder.InsertData(
                table: "kulture",
                columns: new[] { "kulturaID", "nazivKulture" },
                values: new object[,]
                {
                    { new Guid("0245a22d-684b-4e81-8395-08dfe8c6dac8"), "Pašnjaci" },
                    { new Guid("055e4525-4401-455a-b5a7-7080803e9efb"), "Šume" },
                    { new Guid("1af29038-928a-46c1-9bee-3d0532b04dea"), "Njive" },
                    { new Guid("29517569-fd26-48dd-a646-0b52790ca6f2"), "Vinogradi" },
                    { new Guid("2d4eeed9-0e71-42cb-8da1-1957f470a1ff"), "Trstici-močvare" },
                    { new Guid("42b48292-0521-4caa-bb61-46a8cbdb9d3a"), "Vrtovi" },
                    { new Guid("b846877d-225d-45f6-a926-0a9def92e7f4"), "Livade" },
                    { new Guid("e41f48a3-97a3-4093-b375-0b352b2e3802"), "Voćnjaci" }
                });

            migrationBuilder.InsertData(
                table: "obliciSvojine",
                columns: new[] { "oblikSvojineID", "nazivOblikaSvojine" },
                values: new object[,]
                {
                    { new Guid("09d1cc19-a993-491e-8bc1-2481f9475a1e"), "Mešovita svojina" },
                    { new Guid("235cfc03-763b-4ed2-9353-65a0898d6ab0"), "Zadružna svojina" },
                    { new Guid("81878ece-4026-40cb-9cf5-077193071211"), "Državna svojina RS" },
                    { new Guid("a828ee07-dac0-44a4-9448-d85a67e4ccf1"), "Društvena svojina" },
                    { new Guid("ac2a129f-03da-4e0c-9ad6-5ab63f13a8b5"), "Drugi oblici" },
                    { new Guid("e174e16d-07ef-43fd-9063-02e6cbc268ca"), "Privatna svojina" },
                    { new Guid("ff6aca81-f31b-406e-b90a-f176882e74e8"), "Državna svojina" }
                });

            migrationBuilder.InsertData(
                table: "obradivosti",
                columns: new[] { "obradivostID", "nazivObradivosti" },
                values: new object[,]
                {
                    { new Guid("70928335-ad90-4a80-b672-99319f915698"), "Ostalo" },
                    { new Guid("e3c5f27b-8757-4026-8131-19c127395922"), "Obradivo" }
                });

            migrationBuilder.InsertData(
                table: "odvodnjavanja",
                columns: new[] { "odvodnjavanjeID", "nazivOdvodnjavanja" },
                values: new object[,]
                {
                    { new Guid("389eab9c-5869-4745-a838-0b9211c227a3"), "Ostalo" },
                    { new Guid("bfd7815f-b9d8-4032-bfcf-9c400c49bc99"), "Odvodnjavano" }
                });

            migrationBuilder.InsertData(
                table: "parcele",
                columns: new[] { "parcelaID", "brojListaNepokretnosti", "brojParcele", "katastarskaOpstinaID", "klasaID", "klasaStvarnoStanje", "korisnikParceleID", "kulturaID", "kulturaStvarnoStanje", "oblikSvojineID", "obradivostID", "obradivostStvarnoStanje", "odvodnjavanjeID", "odvodnjavanjeStvarnoStanje", "povrsina", "zasticenaZonaID", "zasticenaZonaStvarnoStanje" },
                values: new object[,]
                {
                    { new Guid("b6194c5f-217a-40a4-99c2-5430096d02db"), "23", "123", new Guid("b41c324d-a885-46ce-93c6-2cf38df6c679"), new Guid("ea46fc42-300c-42bd-85ec-b41864c5bfc8"), "da", new Guid("a182e614-9937-4391-8eaf-32e15e072f7f"), new Guid("1af29038-928a-46c1-9bee-3d0532b04dea"), "da", new Guid("ac2a129f-03da-4e0c-9ad6-5ab63f13a8b5"), new Guid("e3c5f27b-8757-4026-8131-19c127395922"), "da", new Guid("389eab9c-5869-4745-a838-0b9211c227a3"), "da", 1152, new Guid("9aa1cd9b-6e6c-4a9e-8840-641070ab5246"), "da" },
                    { new Guid("ed20eaf8-65ff-4a29-a564-ad7cfc08f7a2"), "43", "124", new Guid("c4e673a1-b52b-4f09-afe4-2d8cd0612ffa"), new Guid("50bfacfe-4048-4bfe-ab1f-5beaeb33e01c"), "da", new Guid("76308391-c1e7-450f-b36c-c289f7562116"), new Guid("42b48292-0521-4caa-bb61-46a8cbdb9d3a"), "da", new Guid("235cfc03-763b-4ed2-9353-65a0898d6ab0"), new Guid("70928335-ad90-4a80-b672-99319f915698"), "da", new Guid("bfd7815f-b9d8-4032-bfcf-9c400c49bc99"), "da", 1362, new Guid("0ff62375-b94c-4415-9ae0-096bb738b8bc"), "da" }
                });

            migrationBuilder.InsertData(
                table: "zasticeneZone",
                columns: new[] { "zasticenaZonaID", "nazivZasticeneZone" },
                values: new object[,]
                {
                    { new Guid("0ff62375-b94c-4415-9ae0-096bb738b8bc"), "1" },
                    { new Guid("7f2f2e22-6324-4c77-a05e-de203e9d4045"), "3" },
                    { new Guid("9aa1cd9b-6e6c-4a9e-8840-641070ab5246"), "4" },
                    { new Guid("ef917114-63cd-43c0-a760-e5657f7581c6"), "2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "deloviParcele");

            migrationBuilder.DropTable(
                name: "katastarskeOpstine");

            migrationBuilder.DropTable(
                name: "klase");

            migrationBuilder.DropTable(
                name: "kulture");

            migrationBuilder.DropTable(
                name: "obliciSvojine");

            migrationBuilder.DropTable(
                name: "obradivosti");

            migrationBuilder.DropTable(
                name: "odvodnjavanja");

            migrationBuilder.DropTable(
                name: "parcele");

            migrationBuilder.DropTable(
                name: "zasticeneZone");
        }
    }
}
