using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDocumentService.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewModelForDefinitionAndAbbrevationV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "DefinitionAndAbbrevation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Definition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abbrevation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestDocumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefinitionAndAbbrevation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefinitionAndAbbrevation_TestDocuments_TestDocumentId",
                        column: x => x.TestDocumentId,
                        principalTable: "TestDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DefinitionAndAbbrevation_TestDocumentId",
                table: "DefinitionAndAbbrevation",
                column: "TestDocumentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DefinitionAndAbbrevation");

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
    }
}
