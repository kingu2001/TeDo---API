using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDocumentService.Migrations
{
    /// <inheritdoc />
    public partial class UpatedNaviProp2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Firms_PlaceOfTesting_PlaceOfTestingId",
                table: "Firms");

            migrationBuilder.DropForeignKey(
                name: "FK_Participant_Firms_FirmId",
                table: "Participant");

            migrationBuilder.DropForeignKey(
                name: "FK_Punches_TestDocuments_TestDocumentId",
                table: "Punches");

            migrationBuilder.DropForeignKey(
                name: "FK_Punches_Test_TestId",
                table: "Punches");

            migrationBuilder.DropForeignKey(
                name: "FK_Revisions_TestDocuments_TestDocumentId",
                table: "Revisions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Revisions",
                table: "Revisions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Punches",
                table: "Punches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Firms",
                table: "Firms");

            migrationBuilder.RenameTable(
                name: "Revisions",
                newName: "Revision");

            migrationBuilder.RenameTable(
                name: "Punches",
                newName: "Punch");

            migrationBuilder.RenameTable(
                name: "Firms",
                newName: "Firm");

            migrationBuilder.RenameIndex(
                name: "IX_Revisions_TestDocumentId",
                table: "Revision",
                newName: "IX_Revision_TestDocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_Punches_TestId",
                table: "Punch",
                newName: "IX_Punch_TestId");

            migrationBuilder.RenameIndex(
                name: "IX_Punches_TestDocumentId",
                table: "Punch",
                newName: "IX_Punch_TestDocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_Firms_PlaceOfTestingId",
                table: "Firm",
                newName: "IX_Firm_PlaceOfTestingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Revision",
                table: "Revision",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Punch",
                table: "Punch",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Firm",
                table: "Firm",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Firm_PlaceOfTesting_PlaceOfTestingId",
                table: "Firm",
                column: "PlaceOfTestingId",
                principalTable: "PlaceOfTesting",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_Firm_FirmId",
                table: "Participant",
                column: "FirmId",
                principalTable: "Firm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Punch_TestDocuments_TestDocumentId",
                table: "Punch",
                column: "TestDocumentId",
                principalTable: "TestDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Punch_Test_TestId",
                table: "Punch",
                column: "TestId",
                principalTable: "Test",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Revision_TestDocuments_TestDocumentId",
                table: "Revision",
                column: "TestDocumentId",
                principalTable: "TestDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Firm_PlaceOfTesting_PlaceOfTestingId",
                table: "Firm");

            migrationBuilder.DropForeignKey(
                name: "FK_Participant_Firm_FirmId",
                table: "Participant");

            migrationBuilder.DropForeignKey(
                name: "FK_Punch_TestDocuments_TestDocumentId",
                table: "Punch");

            migrationBuilder.DropForeignKey(
                name: "FK_Punch_Test_TestId",
                table: "Punch");

            migrationBuilder.DropForeignKey(
                name: "FK_Revision_TestDocuments_TestDocumentId",
                table: "Revision");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Revision",
                table: "Revision");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Punch",
                table: "Punch");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Firm",
                table: "Firm");

            migrationBuilder.RenameTable(
                name: "Revision",
                newName: "Revisions");

            migrationBuilder.RenameTable(
                name: "Punch",
                newName: "Punches");

            migrationBuilder.RenameTable(
                name: "Firm",
                newName: "Firms");

            migrationBuilder.RenameIndex(
                name: "IX_Revision_TestDocumentId",
                table: "Revisions",
                newName: "IX_Revisions_TestDocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_Punch_TestId",
                table: "Punches",
                newName: "IX_Punches_TestId");

            migrationBuilder.RenameIndex(
                name: "IX_Punch_TestDocumentId",
                table: "Punches",
                newName: "IX_Punches_TestDocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_Firm_PlaceOfTestingId",
                table: "Firms",
                newName: "IX_Firms_PlaceOfTestingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Revisions",
                table: "Revisions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Punches",
                table: "Punches",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Firms",
                table: "Firms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Firms_PlaceOfTesting_PlaceOfTestingId",
                table: "Firms",
                column: "PlaceOfTestingId",
                principalTable: "PlaceOfTesting",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_Firms_FirmId",
                table: "Participant",
                column: "FirmId",
                principalTable: "Firms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Punches_TestDocuments_TestDocumentId",
                table: "Punches",
                column: "TestDocumentId",
                principalTable: "TestDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Punches_Test_TestId",
                table: "Punches",
                column: "TestId",
                principalTable: "Test",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Revisions_TestDocuments_TestDocumentId",
                table: "Revisions",
                column: "TestDocumentId",
                principalTable: "TestDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
