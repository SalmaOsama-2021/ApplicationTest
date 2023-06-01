using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApplication.Server.Migrations
{
    public partial class first22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_student_parentId",
                table: "student");

            migrationBuilder.DropColumn(
                name: "studId",
                table: "Parent");

            migrationBuilder.CreateIndex(
                name: "IX_student_parentId",
                table: "student",
                column: "parentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_student_parentId",
                table: "student");

            migrationBuilder.AddColumn<int>(
                name: "studId",
                table: "Parent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_student_parentId",
                table: "student",
                column: "parentId",
                unique: true);
        }
    }
}
