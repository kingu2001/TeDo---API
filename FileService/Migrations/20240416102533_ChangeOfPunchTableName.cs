using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileService.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOfPunchTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_punches_Documents_SignedDocumentId",
                table: "punches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_punches",
                table: "punches");

            migrationBuilder.RenameTable(
                name: "punches",
                newName: "Punches");

            migrationBuilder.RenameIndex(
                name: "IX_punches_SignedDocumentId",
                table: "Punches",
                newName: "IX_Punches_SignedDocumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Punches",
                table: "Punches",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Punches_Documents_SignedDocumentId",
                table: "Punches",
                column: "SignedDocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Punches_Documents_SignedDocumentId",
                table: "Punches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Punches",
                table: "Punches");

            migrationBuilder.RenameTable(
                name: "Punches",
                newName: "punches");

            migrationBuilder.RenameIndex(
                name: "IX_Punches_SignedDocumentId",
                table: "punches",
                newName: "IX_punches_SignedDocumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_punches",
                table: "punches",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_punches_Documents_SignedDocumentId",
                table: "punches",
                column: "SignedDocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
