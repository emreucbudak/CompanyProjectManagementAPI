using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskProjectManagementApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "answerStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_answerStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "missionStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_missionStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "companiesAuthor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companiesAuthor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_companiesAuthor_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reporterWorkers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reporterWorkers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reporterWorkers_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_teams_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teamMissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MissionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MissionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MissionStatusId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teamMissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_teamMissions_missionStatuses_MissionStatusId",
                        column: x => x.MissionStatusId,
                        principalTable: "missionStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teamMissions_teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    IsLeaved = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_workers_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_workers_teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "teamMissionsAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamMissionsId = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerStatusId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teamMissionsAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_teamMissionsAnswers_answerStatuses_AnswerStatusId",
                        column: x => x.AnswerStatusId,
                        principalTable: "answerStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teamMissionsAnswers_teamMissions_TeamMissionsId",
                        column: x => x.TeamMissionsId,
                        principalTable: "teamMissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "allReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReporterWorkerId = table.Column<int>(type: "int", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: true),
                    MissionStatusId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_allReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_allReports_missionStatuses_MissionStatusId",
                        column: x => x.MissionStatusId,
                        principalTable: "missionStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_allReports_reporterWorkers_ReporterWorkerId",
                        column: x => x.ReporterWorkerId,
                        principalTable: "reporterWorkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_allReports_workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "workers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "individualMissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    MissionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MissionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MissionStatusId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_individualMissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_individualMissions_missionStatuses_MissionStatusId",
                        column: x => x.MissionStatusId,
                        principalTable: "missionStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_individualMissions_workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndividualMissionsAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndividualMissionsId = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerStatusId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualMissionsAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualMissionsAnswers_answerStatuses_AnswerStatusId",
                        column: x => x.AnswerStatusId,
                        principalTable: "answerStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndividualMissionsAnswers_individualMissions_IndividualMissionsId",
                        column: x => x.IndividualMissionsId,
                        principalTable: "individualMissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "answerStatuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { 1, "İnceleniyor" },
                    { 2, "Onaylandı" },
                    { 3, "Reddedildi" }
                });

            migrationBuilder.InsertData(
                table: "missionStatuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { 1, "Başlamadı" },
                    { 2, "Devam Ediyor" },
                    { 3, "Tamamlandı" },
                    { 4, "İptal Edildi" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_allReports_MissionStatusId",
                table: "allReports",
                column: "MissionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_allReports_ReporterWorkerId",
                table: "allReports",
                column: "ReporterWorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_allReports_WorkerId",
                table: "allReports",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_companiesAuthor_CompanyId",
                table: "companiesAuthor",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualMissionsAnswers_AnswerStatusId",
                table: "IndividualMissionsAnswers",
                column: "AnswerStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualMissionsAnswers_IndividualMissionsId",
                table: "IndividualMissionsAnswers",
                column: "IndividualMissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_individualMissions_MissionStatusId",
                table: "individualMissions",
                column: "MissionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_individualMissions_WorkerId",
                table: "individualMissions",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_reporterWorkers_CompanyId",
                table: "reporterWorkers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_teamMissions_MissionStatusId",
                table: "teamMissions",
                column: "MissionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_teamMissions_TeamId",
                table: "teamMissions",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_teamMissionsAnswers_AnswerStatusId",
                table: "teamMissionsAnswers",
                column: "AnswerStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_teamMissionsAnswers_TeamMissionsId",
                table: "teamMissionsAnswers",
                column: "TeamMissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_teams_CompanyId",
                table: "teams",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_workers_CompanyId",
                table: "workers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_workers_TeamId",
                table: "workers",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "allReports");

            migrationBuilder.DropTable(
                name: "companiesAuthor");

            migrationBuilder.DropTable(
                name: "IndividualMissionsAnswers");

            migrationBuilder.DropTable(
                name: "teamMissionsAnswers");

            migrationBuilder.DropTable(
                name: "reporterWorkers");

            migrationBuilder.DropTable(
                name: "individualMissions");

            migrationBuilder.DropTable(
                name: "answerStatuses");

            migrationBuilder.DropTable(
                name: "teamMissions");

            migrationBuilder.DropTable(
                name: "workers");

            migrationBuilder.DropTable(
                name: "missionStatuses");

            migrationBuilder.DropTable(
                name: "teams");

            migrationBuilder.DropTable(
                name: "companies");
        }
    }
}
