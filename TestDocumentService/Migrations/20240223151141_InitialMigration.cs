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
                name: "PlaceOfTesting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestType = table.Column<int>(type: "int", nullable: false),
                    FimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceOfTesting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestProcedure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IATInitials = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATInitials = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SATInitials = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OATInitials = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PuchId = table.Column<int>(type: "int", nullable: true),
                    TestDocumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
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
                name: "Firms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfTestingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Firms_PlaceOfTesting_PlaceOfTestingId",
                        column: x => x.PlaceOfTestingId,
                        principalTable: "PlaceOfTesting",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlaceOfTestingTestDocument",
                columns: table => new
                {
                    PlaceOfTestingsId = table.Column<int>(type: "int", nullable: false),
                    TestDocumentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceOfTestingTestDocument", x => new { x.PlaceOfTestingsId, x.TestDocumentsId });
                    table.ForeignKey(
                        name: "FK_PlaceOfTestingTestDocument_PlaceOfTesting_PlaceOfTestingsId",
                        column: x => x.PlaceOfTestingsId,
                        principalTable: "PlaceOfTesting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaceOfTestingTestDocument_TestDocuments_TestDocumentsId",
                        column: x => x.TestDocumentsId,
                        principalTable: "TestDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Punches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PunchNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    TestDocumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Punches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Punches_TestDocuments_TestDocumentId",
                        column: x => x.TestDocumentId,
                        principalTable: "TestDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Punches_Test_TestId",
                        column: x => x.TestId,
                        principalTable: "Test",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Revisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    PageAffected = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChapterAffected = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestDocumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Revisions_TestDocuments_TestDocumentId",
                        column: x => x.TestDocumentId,
                        principalTable: "TestDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestTestDocument",
                columns: table => new
                {
                    TestDocumentId = table.Column<int>(type: "int", nullable: false),
                    TestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTestDocument", x => new { x.TestDocumentId, x.TestsId });
                    table.ForeignKey(
                        name: "FK_TestTestDocument_TestDocuments_TestDocumentId",
                        column: x => x.TestDocumentId,
                        principalTable: "TestDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestTestDocument_Test_TestsId",
                        column: x => x.TestsId,
                        principalTable: "Test",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Signature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participant_Firms_FirmId",
                        column: x => x.FirmId,
                        principalTable: "Firms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_Firms_PlaceOfTestingId",
                table: "Firms",
                column: "PlaceOfTestingId",
                unique: true,
                filter: "[PlaceOfTestingId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_FirmId",
                table: "Participant",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantTestDocument_TestDocumentsId",
                table: "ParticipantTestDocument",
                column: "TestDocumentsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceOfTestingTestDocument_TestDocumentsId",
                table: "PlaceOfTestingTestDocument",
                column: "TestDocumentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Punches_TestDocumentId",
                table: "Punches",
                column: "TestDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Punches_TestId",
                table: "Punches",
                column: "TestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Revisions_TestDocumentId",
                table: "Revisions",
                column: "TestDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_TestTestDocument_TestsId",
                table: "TestTestDocument",
                column: "TestsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParticipantTestDocument");

            migrationBuilder.DropTable(
                name: "PlaceOfTestingTestDocument");

            migrationBuilder.DropTable(
                name: "Punches");

            migrationBuilder.DropTable(
                name: "Revisions");

            migrationBuilder.DropTable(
                name: "TestTestDocument");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "TestDocuments");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "Firms");

            migrationBuilder.DropTable(
                name: "PlaceOfTesting");
        }
    }
}
