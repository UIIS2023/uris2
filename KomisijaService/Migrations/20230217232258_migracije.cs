using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KomisijaService.Migrations
{
    /// <inheritdoc />
    public partial class migracije : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clanovi",
                columns: table => new
                {
                    clanoviID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    komisijaID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clanovi", x => x.clanoviID);
                });

            migrationBuilder.CreateTable(
                name: "Komisija",
                columns: table => new
                {
                    komisijaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    predsednikID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komisija", x => x.komisijaID);
                });

            migrationBuilder.CreateTable(
                name: "Predsednik",
                columns: table => new
                {
                    predsednikID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predsednik", x => x.predsednikID);
                });

            migrationBuilder.InsertData(
                table: "Clanovi",
                columns: new[] { "clanoviID", "komisijaID" },
                values: new object[,]
                {
                    { new Guid("06cfa3e0-6d39-46c6-b5bb-98e0a64a9637"), new Guid("bf1c58fd-ba25-4bd9-837a-37c06ad29ea5") },
                    { new Guid("c84a7948-81c5-44d2-86c1-c601fdab526b"), new Guid("0648b913-c49e-4939-95ae-10185e475ef7") },
                    { new Guid("ea3d75d9-61aa-4cc5-9e2a-6f01190b9044"), new Guid("c1b8a40c-0e1c-44a6-87d2-1593ab638e94") }
                });

            migrationBuilder.InsertData(
                table: "Komisija",
                columns: new[] { "komisijaID", "predsednikID" },
                values: new object[,]
                {
                    { new Guid("0648b913-c49e-4939-95ae-10185e475ef7"), new Guid("efcbf7d7-de6b-4468-a8f7-d3907d541262") },
                    { new Guid("bf1c58fd-ba25-4bd9-837a-37c06ad29ea5"), new Guid("ebfc69f7-8626-48c4-8c92-c06ca85cf7b1") },
                    { new Guid("c1b8a40c-0e1c-44a6-87d2-1593ab638e94"), new Guid("61ef85bf-765a-4a53-a50a-9d99255cdeaf") }
                });

            migrationBuilder.InsertData(
                table: "Predsednik",
                column: "predsednikID",
                values: new object[]
                {
                    new Guid("61ef85bf-765a-4a53-a50a-9d99255cdeaf"),
                    new Guid("ebfc69f7-8626-48c4-8c92-c06ca85cf7b1"),
                    new Guid("efcbf7d7-de6b-4468-a8f7-d3907d541262")
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clanovi");

            migrationBuilder.DropTable(
                name: "Komisija");

            migrationBuilder.DropTable(
                name: "Predsednik");
        }
    }
}
