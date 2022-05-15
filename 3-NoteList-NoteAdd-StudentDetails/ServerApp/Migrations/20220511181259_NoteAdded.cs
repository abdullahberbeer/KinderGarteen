using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerApp.Migrations
{
    public partial class NoteAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonNote");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Notes",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "Notes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PeriodId",
                table: "Notes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Notes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Notes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Lessons",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "Period",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Period", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_LessonId",
                table: "Notes",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_PeriodId",
                table: "Notes",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_StudentId",
                table: "Notes",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_TeacherId",
                table: "Notes",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_AspNetUsers_StudentId",
                table: "Notes",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_AspNetUsers_TeacherId",
                table: "Notes",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Lessons_LessonId",
                table: "Notes",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Period_PeriodId",
                table: "Notes",
                column: "PeriodId",
                principalTable: "Period",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_AspNetUsers_StudentId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_AspNetUsers_TeacherId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Lessons_LessonId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Period_PeriodId",
                table: "Notes");

            migrationBuilder.DropTable(
                name: "Period");

            migrationBuilder.DropIndex(
                name: "IX_Notes_LessonId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_PeriodId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_StudentId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_TeacherId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Notes");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Notes",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Lessons",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "LessonNote",
                columns: table => new
                {
                    LessonsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    NotesId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonNote", x => new { x.LessonsId, x.NotesId });
                    table.ForeignKey(
                        name: "FK_LessonNote_Lessons_LessonsId",
                        column: x => x.LessonsId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonNote_Notes_NotesId",
                        column: x => x.NotesId,
                        principalTable: "Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonNote_NotesId",
                table: "LessonNote",
                column: "NotesId");
        }
    }
}
