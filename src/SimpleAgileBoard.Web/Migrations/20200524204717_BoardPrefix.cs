using Microsoft.EntityFrameworkCore.Migrations;

namespace Boilerplate.Migrations
{
    public partial class BoardPrefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NoteBoardId",
                table: "Notes",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "NoteCounter",
                table: "Boards",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "NotePrefix",
                table: "Boards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoteBoardId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "NoteCounter",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "NotePrefix",
                table: "Boards");
        }
    }
}
