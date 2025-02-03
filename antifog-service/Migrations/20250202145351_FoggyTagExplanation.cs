using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace antifog_service.Migrations
{
    /// <inheritdoc />
    public partial class FoggyTagExplanation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Explanation",
                schema: "default",
                table: "FoggyTag",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Explanation",
                schema: "default",
                table: "FoggyTag");
        }
    }
}
