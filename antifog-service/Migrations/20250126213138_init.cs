using System;
using Microsoft.EntityFrameworkCore.Migrations;
using antifog_service.Models.Primary;

#nullable disable

namespace antifog_service.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "default");

            migrationBuilder.CreateTable(
                name: "FoggyInformation",
                schema: "default",
                columns: table => new
                {
                    FoggyInformationId = table.Column<Guid>(type: "uuid", nullable: false),
                    InformationText = table.Column<string>(type: "text", nullable: false),
                    TagInfo = table.Column<FoggyInformationTagInfo>(type: "jsonb", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoggyInformation", x => x.FoggyInformationId);
                });

            migrationBuilder.CreateTable(
                name: "FoggyTag",
                schema: "default",
                columns: table => new
                {
                    FoggyTagId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagName = table.Column<string>(type: "varchar(127)", nullable: false),
                    FoggyTagDataStructure = table.Column<FoggyTagDataStructure>(type: "jsonb", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoggyTag", x => x.FoggyTagId);
                });

            migrationBuilder.CreateTable(
                name: "GrizhlaHistory",
                schema: "default",
                columns: table => new
                {
                    HistoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelName = table.Column<string>(type: "varchar(63)", nullable: false),
                    PrimaryKey = table.Column<string>(type: "varchar(63)", nullable: false),
                    DBMethod = table.Column<int>(type: "integer", nullable: false),
                    OldState = table.Column<string>(type: "jsonb", nullable: true),
                    NewState = table.Column<string>(type: "jsonb", nullable: true),
                    OnTime = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrizhlaHistory", x => x.HistoryId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoggyInformation",
                schema: "default");

            migrationBuilder.DropTable(
                name: "FoggyTag",
                schema: "default");

            migrationBuilder.DropTable(
                name: "GrizhlaHistory",
                schema: "default");
        }
    }
}
