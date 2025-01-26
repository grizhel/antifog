using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace antifog_service.Migrations
{
    /// <inheritdoc />
    public partial class History_alter_column__AtTime_2_Time : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OnTime",
                schema: "default",
                table: "GrizhlaHistory",
                newName: "Time");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                schema: "default",
                table: "GrizhlaHistory",
                newName: "OnTime");
        }
    }
}
