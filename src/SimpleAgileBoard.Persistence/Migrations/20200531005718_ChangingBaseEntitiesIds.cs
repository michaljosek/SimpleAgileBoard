using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleAgileBoard.Persistence.Migrations
{
    public partial class ChangingBaseEntitiesIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lanes_Boards_BoardId",
                table: "Lanes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Lanes_LaneId",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lanes",
                table: "Lanes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Boards",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "NoteId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "LaneId",
                table: "Lanes");

            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "Boards");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Notes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Lanes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Boards",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lanes",
                table: "Lanes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Boards",
                table: "Boards",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lanes_Boards_BoardId",
                table: "Lanes",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Lanes_LaneId",
                table: "Notes",
                column: "LaneId",
                principalTable: "Lanes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lanes_Boards_BoardId",
                table: "Lanes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Lanes_LaneId",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lanes",
                table: "Lanes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Boards",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Lanes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Boards");

            migrationBuilder.AddColumn<int>(
                name: "NoteId",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "LaneId",
                table: "Lanes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "BoardId",
                table: "Boards",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                column: "NoteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lanes",
                table: "Lanes",
                column: "LaneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Boards",
                table: "Boards",
                column: "BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lanes_Boards_BoardId",
                table: "Lanes",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "BoardId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Lanes_LaneId",
                table: "Notes",
                column: "LaneId",
                principalTable: "Lanes",
                principalColumn: "LaneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
