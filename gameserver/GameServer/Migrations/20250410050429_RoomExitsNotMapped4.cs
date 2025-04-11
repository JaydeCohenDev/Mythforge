using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameServer.Migrations
{
    /// <inheritdoc />
    public partial class RoomExitsNotMapped4 : Migration
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

            migrationBuilder.CreateTable(
                name: "RoomLink",
                columns: table => new
                {
                    ExitsId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomLink", x => new { x.ExitsId, x.RoomId });
                    table.ForeignKey(
                        name: "FK_RoomLink_Room_ExitsId",
                        column: x => x.ExitsId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomLink_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomLink_RoomId",
                table: "RoomLink",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomLink");

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
