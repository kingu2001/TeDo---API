using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileService.Migrations
{
    /// <inheritdoc />
    public partial class DeletedNavPropStamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stamps_Documents_SignedDocumentId",
                table: "Stamps");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Certificates");

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
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Certificates",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddForeignKey(
                name: "FK_Stamps_Documents_SignedDocumentId",
                table: "Stamps",
                column: "SignedDocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
