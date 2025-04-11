using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameServer.Migrations
{
    /// <inheritdoc />
    public partial class RoomExitsNotMapped : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_Room_RoomId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_RoomId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Room");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Room",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomId",
                table: "Room",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Room_RoomId",
                table: "Room",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id");
        }
    }
}
