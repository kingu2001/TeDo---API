using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileService.Migrations
{
    /// <inheritdoc />
    public partial class ChangedNavProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stamps_Documents_SignedDocumentId",
                table: "Stamps");

            migrationBuilder.AlterColumn<int>(
                name: "SignedDocumentId",
                table: "Stamps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stamps_Documents_SignedDocumentId",
                table: "Stamps",
                column: "SignedDocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stamps_Documents_SignedDocumentId",
                table: "Stamps");

            migrationBuilder.AlterColumn<int>(
                name: "SignedDocumentId",
                table: "Stamps",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Stamps_Documents_SignedDocumentId",
                table: "Stamps",
                column: "SignedDocumentId",
                principalTable: "Documents",
                principalColumn: "Id");
        }
    }
}
