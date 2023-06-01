using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApplication.Server.Migrations
{
    public partial class initialfirst2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "student",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isEnabled",
                table: "student",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Parent",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isEnabled",
                table: "Parent",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "student");

            migrationBuilder.DropColumn(
                name: "isEnabled",
                table: "student");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Parent");

            migrationBuilder.DropColumn(
                name: "isEnabled",
                table: "Parent");
        }
    }
}
