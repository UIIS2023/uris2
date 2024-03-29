﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OvlascenoLice.Migrations
{
    /// <inheritdoc />
    public partial class migracije : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OvlascenaLica",
                columns: table => new
                {
                    OvlascenoLiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojDokumenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OvlascenaLica", x => x.OvlascenoLiceID);
                });

            migrationBuilder.InsertData(
                table: "OvlascenaLica",
                columns: new[] { "OvlascenoLiceID", "AdresaID", "BrojDokumenta", "BrojTable", "Ime", "Prezime" },
                values: new object[,]
                {
                    { new Guid("5dc3dfcd-de07-4e5f-878e-a07636db322f"), new Guid("7280c84a-a070-4516-94e7-ef905c7dcf8b"), "4585248", "74474", "Sara", "Kijanovic" },
                    { new Guid("668e0c43-810b-4443-82a7-649b4f25a840"), new Guid("4ead0649-3ad7-42cb-92b3-80e504006df9"), "465548", "7434664", "Marko", "Ruzic" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OvlascenaLica");
        }
    }
}
