using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace antifog_service.Migrations
{
    /// <inheritdoc />
    public partial class FoggyTagTagNameUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FoggyTag_TagName",
                schema: "default",
                table: "FoggyTag",
                column: "TagName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FoggyTag_TagName",
                schema: "default",
                table: "FoggyTag");
        }
    }
}
