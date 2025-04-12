using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameServer.Migrations
{
    /// <inheritdoc />
    public partial class playerloginroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoginRoomId",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Players_LoginRoomId",
                table: "Players",
                column: "LoginRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Room_LoginRoomId",
                table: "Players",
                column: "LoginRoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Room_LoginRoomId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_LoginRoomId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "LoginRoomId",
                table: "Players");
        }
    }
}
