using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDocumentService.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Firm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SAT = table.Column<bool>(type: "bit", nullable: false),
                    IAT = table.Column<bool>(type: "bit", nullable: false),
                    OAT = table.Column<bool>(type: "bit", nullable: false),
                    FAT = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Introduction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentSupplied = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Signature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participant_Firm_FirmId",
                        column: x => x.FirmId,
                        principalTable: "Firm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "FirmTestDocument",
                columns: table => new
                {
                    FirmsId = table.Column<int>(type: "int", nullable: false),
                    TestDocumentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirmTestDocument", x => new { x.FirmsId, x.TestDocumentsId });
                    table.ForeignKey(
                        name: "FK_FirmTestDocument_Firm_FirmsId",
                        column: x => x.FirmsId,
                        principalTable: "Firm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FirmTestDocument_TestDocuments_TestDocumentsId",
                        column: x => x.TestDocumentsId,
                        principalTable: "TestDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Revision",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageAffected = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChapterAffected = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestDocumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revision", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Revision_TestDocuments_TestDocumentId",
                        column: x => x.TestDocumentId,
                        principalTable: "TestDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestProcedure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IATInitials = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATInitials = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SATInitials = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OATInitials = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestDocumentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Test_TestDocuments_TestDocumentId",
                        column: x => x.TestDocumentId,
                        principalTable: "TestDocuments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ParticipantTestDocument",
                columns: table => new
                {
                    ParticipantsId = table.Column<int>(type: "int", nullable: false),
                    TestDocumentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantTestDocument", x => new { x.ParticipantsId, x.TestDocumentsId });
                    table.ForeignKey(
                        name: "FK_ParticipantTestDocument_Participant_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "Participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantTestDocument_TestDocuments_TestDocumentsId",
                        column: x => x.TestDocumentsId,
                        principalTable: "TestDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Punch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PunchNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    TestDocumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Punch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Punch_TestDocuments_TestDocumentId",
                        column: x => x.TestDocumentId,
                        principalTable: "TestDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Punch_Test_TestId",
                        column: x => x.TestId,
                        principalTable: "Test",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DefinitionAndAbbrevation_TestDocumentId",
                table: "DefinitionAndAbbrevation",
                column: "TestDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_FirmTestDocument_TestDocumentsId",
                table: "FirmTestDocument",
                column: "TestDocumentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_FirmId",
                table: "Participant",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantTestDocument_TestDocumentsId",
                table: "ParticipantTestDocument",
                column: "TestDocumentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Punch_TestDocumentId",
                table: "Punch",
                column: "TestDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Punch_TestId",
                table: "Punch",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Revision_TestDocumentId",
                table: "Revision",
                column: "TestDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Test_TestDocumentId",
                table: "Test",
                column: "TestDocumentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DefinitionAndAbbrevation");

            migrationBuilder.DropTable(
                name: "FirmTestDocument");

            migrationBuilder.DropTable(
                name: "ParticipantTestDocument");

            migrationBuilder.DropTable(
                name: "Punch");

            migrationBuilder.DropTable(
                name: "Revision");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "Firm");

            migrationBuilder.DropTable(
                name: "TestDocuments");
        }
    }
}
