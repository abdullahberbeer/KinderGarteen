using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerApp.Migrations
{
    public partial class NoteAddedTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Classes_ClassesId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Period_PeriodId",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Period",
                table: "Period");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classes",
                table: "Classes");

            migrationBuilder.RenameTable(
                name: "Period",
                newName: "Periods");

            migrationBuilder.RenameTable(
                name: "Classes",
                newName: "Classess");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Periods",
                table: "Periods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classess",
                table: "Classess",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Classess_ClassesId",
                table: "AspNetUsers",
                column: "ClassesId",
                principalTable: "Classess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Periods_PeriodId",
                table: "Notes",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Classess_ClassesId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Periods_PeriodId",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Periods",
                table: "Periods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classess",
                table: "Classess");

            migrationBuilder.RenameTable(
                name: "Periods",
                newName: "Period");

            migrationBuilder.RenameTable(
                name: "Classess",
                newName: "Classes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Period",
                table: "Period",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classes",
                table: "Classes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Classes_ClassesId",
                table: "AspNetUsers",
                column: "ClassesId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Period_PeriodId",
                table: "Notes",
                column: "PeriodId",
                principalTable: "Period",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
