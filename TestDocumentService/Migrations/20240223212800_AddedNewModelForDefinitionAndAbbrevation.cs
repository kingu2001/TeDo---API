using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDocumentService.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewModelForDefinitionAndAbbrevation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestDocumentId",
                table: "TestDocuments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestDocuments_TestDocumentId",
                table: "TestDocuments",
                column: "TestDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestDocuments_TestDocuments_TestDocumentId",
                table: "TestDocuments",
                column: "TestDocumentId",
                principalTable: "TestDocuments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestDocuments_TestDocuments_TestDocumentId",
                table: "TestDocuments");

            migrationBuilder.DropIndex(
                name: "IX_TestDocuments_TestDocumentId",
                table: "TestDocuments");

            migrationBuilder.DropColumn(
                name: "TestDocumentId",
                table: "TestDocuments");
        }
    }
}
