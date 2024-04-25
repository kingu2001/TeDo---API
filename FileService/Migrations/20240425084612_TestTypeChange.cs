using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileService.Migrations
{
    /// <inheritdoc />
    public partial class TestTypeChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestType",
                table: "Documents");

            migrationBuilder.AddColumn<string>(
                name: "TestType",
                table: "Stamps",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestType",
                table: "Stamps");

            migrationBuilder.AddColumn<string>(
                name: "TestType",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
