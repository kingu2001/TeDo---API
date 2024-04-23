using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileService.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedStamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Signess",
                table: "Documents");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Stamps",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "SigneeName",
                table: "Stamps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StampIdentity",
                table: "Stamps",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SigneeName",
                table: "Stamps");

            migrationBuilder.DropColumn(
                name: "StampIdentity",
                table: "Stamps");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Stamps",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Signess",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
