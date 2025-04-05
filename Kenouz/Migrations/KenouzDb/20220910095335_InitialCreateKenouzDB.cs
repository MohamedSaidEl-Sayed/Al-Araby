using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kenouz.Migrations.KenouzDb
{
    public partial class InitialCreateKenouzDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassYears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PdfQuizzes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassYearId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdfQuizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PdfQuizzes_ClassYears_ClassYearId",
                        column: x => x.ClassYearId,
                        principalTable: "ClassYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizPerLessonCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    ClassYearId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizPerLessonCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizPerLessonCategories_ClassYears_ClassYearId",
                        column: x => x.ClassYearId,
                        principalTable: "ClassYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RateYourselfQuizzes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false),
                    ClassYearId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateYourselfQuizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RateYourselfQuizzes_ClassYears_ClassYearId",
                        column: x => x.ClassYearId,
                        principalTable: "ClassYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeachingCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    ClassYearId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachingCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeachingCategories_ClassYears_ClassYearId",
                        column: x => x.ClassYearId,
                        principalTable: "ClassYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizPerLessonCategoryUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    QuizPerLessonCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizPerLessonCategoryUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizPerLessonCategoryUnits_QuizPerLessonCategories_QuizPerLessonCategoryId",
                        column: x => x.QuizPerLessonCategoryId,
                        principalTable: "QuizPerLessonCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RateYourselfQuizScripts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Script = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    RateYourselfQuizId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateYourselfQuizScripts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RateYourselfQuizScripts_RateYourselfQuizzes_RateYourselfQuizId",
                        column: x => x.RateYourselfQuizId,
                        principalTable: "RateYourselfQuizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeachingCategoryUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    TeachingCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachingCategoryUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeachingCategoryUnits_TeachingCategories_TeachingCategoryId",
                        column: x => x.TeachingCategoryId,
                        principalTable: "TeachingCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizPerLessonCategoryUnitLessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    QuizPerLessonCategoryUnitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizPerLessonCategoryUnitLessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizPerLessonCategoryUnitLessons_QuizPerLessonCategoryUnits_QuizPerLessonCategoryUnitId",
                        column: x => x.QuizPerLessonCategoryUnitId,
                        principalTable: "QuizPerLessonCategoryUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RateYourselfQuizScriptQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionTitle = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    Answer1 = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Answer2 = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Answer3 = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Answer4 = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Answer5 = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    RightAnswer = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    RateYourselfQuizScriptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateYourselfQuizScriptQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RateYourselfQuizScriptQuestions_RateYourselfQuizScripts_RateYourselfQuizScriptId",
                        column: x => x.RateYourselfQuizScriptId,
                        principalTable: "RateYourselfQuizScripts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeachingCategoryUnitLessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    VideoLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PdfLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeachingCategoryUnitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachingCategoryUnitLessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeachingCategoryUnitLessons_TeachingCategoryUnits_TeachingCategoryUnitId",
                        column: x => x.TeachingCategoryUnitId,
                        principalTable: "TeachingCategoryUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizPerLessonCategoryUnitLessonQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Script = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    QuestionTitle = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    Answer1 = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Answer2 = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Answer3 = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Answer4 = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Answer5 = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    RightAnswer = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Minutes = table.Column<int>(type: "int", nullable: false),
                    Seconds = table.Column<int>(type: "int", nullable: false),
                    QuizPerLessonCategoryUnitLessonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizPerLessonCategoryUnitLessonQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizPerLessonCategoryUnitLessonQuestions_QuizPerLessonCategoryUnitLessons_QuizPerLessonCategoryUnitLessonId",
                        column: x => x.QuizPerLessonCategoryUnitLessonId,
                        principalTable: "QuizPerLessonCategoryUnitLessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PdfQuizzes_ClassYearId",
                table: "PdfQuizzes",
                column: "ClassYearId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizPerLessonCategories_ClassYearId",
                table: "QuizPerLessonCategories",
                column: "ClassYearId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizPerLessonCategoryUnitLessonQuestions_QuizPerLessonCategoryUnitLessonId",
                table: "QuizPerLessonCategoryUnitLessonQuestions",
                column: "QuizPerLessonCategoryUnitLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizPerLessonCategoryUnitLessons_QuizPerLessonCategoryUnitId",
                table: "QuizPerLessonCategoryUnitLessons",
                column: "QuizPerLessonCategoryUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizPerLessonCategoryUnits_QuizPerLessonCategoryId",
                table: "QuizPerLessonCategoryUnits",
                column: "QuizPerLessonCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RateYourselfQuizScriptQuestions_RateYourselfQuizScriptId",
                table: "RateYourselfQuizScriptQuestions",
                column: "RateYourselfQuizScriptId");

            migrationBuilder.CreateIndex(
                name: "IX_RateYourselfQuizScripts_RateYourselfQuizId",
                table: "RateYourselfQuizScripts",
                column: "RateYourselfQuizId");

            migrationBuilder.CreateIndex(
                name: "IX_RateYourselfQuizzes_ClassYearId",
                table: "RateYourselfQuizzes",
                column: "ClassYearId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingCategories_ClassYearId",
                table: "TeachingCategories",
                column: "ClassYearId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingCategoryUnitLessons_TeachingCategoryUnitId",
                table: "TeachingCategoryUnitLessons",
                column: "TeachingCategoryUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingCategoryUnits_TeachingCategoryId",
                table: "TeachingCategoryUnits",
                column: "TeachingCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PdfQuizzes");

            migrationBuilder.DropTable(
                name: "QuizPerLessonCategoryUnitLessonQuestions");

            migrationBuilder.DropTable(
                name: "RateYourselfQuizScriptQuestions");

            migrationBuilder.DropTable(
                name: "TeachingCategoryUnitLessons");

            migrationBuilder.DropTable(
                name: "QuizPerLessonCategoryUnitLessons");

            migrationBuilder.DropTable(
                name: "RateYourselfQuizScripts");

            migrationBuilder.DropTable(
                name: "TeachingCategoryUnits");

            migrationBuilder.DropTable(
                name: "QuizPerLessonCategoryUnits");

            migrationBuilder.DropTable(
                name: "RateYourselfQuizzes");

            migrationBuilder.DropTable(
                name: "TeachingCategories");

            migrationBuilder.DropTable(
                name: "QuizPerLessonCategories");

            migrationBuilder.DropTable(
                name: "ClassYears");
        }
    }
}
