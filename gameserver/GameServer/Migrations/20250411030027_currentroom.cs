using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameServer.Migrations
{
    /// <inheritdoc />
    public partial class currentroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Room_RoomId",
                table: "Entity");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Entity",
                newName: "CurrentRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Entity_RoomId",
                table: "Entity",
                newName: "IX_Entity_CurrentRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Room_CurrentRoomId",
                table: "Entity",
                column: "CurrentRoomId",
                principalTable: "Room",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Room_CurrentRoomId",
                table: "Entity");

            migrationBuilder.RenameColumn(
                name: "CurrentRoomId",
                table: "Entity",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Entity_CurrentRoomId",
                table: "Entity",
                newName: "IX_Entity_RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Room_RoomId",
                table: "Entity",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id");
        }
    }
}
