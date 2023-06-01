using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApplication.Server.Migrations
{
    public partial class initialfirst3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parent_student_StudentId",
                table: "Parent");

            migrationBuilder.DropIndex(
                name: "IX_Parent_StudentId",
                table: "Parent");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Parent");

            migrationBuilder.AddColumn<int>(
                name: "parentId",
                table: "student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_student_parentId",
                table: "student",
                column: "parentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_student_Parent_parentId",
                table: "student",
                column: "parentId",
                principalTable: "Parent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_student_Parent_parentId",
                table: "student");

            migrationBuilder.DropIndex(
                name: "IX_student_parentId",
                table: "student");

            migrationBuilder.DropColumn(
                name: "parentId",
                table: "student");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Parent",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parent_StudentId",
                table: "Parent",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parent_student_StudentId",
                table: "Parent",
                column: "StudentId",
                principalTable: "student",
                principalColumn: "Id");
        }
    }
}
