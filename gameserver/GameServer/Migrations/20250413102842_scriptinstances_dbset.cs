using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameServer.Migrations
{
    /// <inheritdoc />
    public partial class scriptinstances_dbset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScriptInstance_Entity_EntityId",
                table: "ScriptInstance");

            migrationBuilder.DropForeignKey(
                name: "FK_ScriptInstance_Room_RoomId",
                table: "ScriptInstance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScriptInstance",
                table: "ScriptInstance");

            migrationBuilder.RenameTable(
                name: "ScriptInstance",
                newName: "ScriptInstances");

            migrationBuilder.RenameIndex(
                name: "IX_ScriptInstance_RoomId",
                table: "ScriptInstances",
                newName: "IX_ScriptInstances_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_ScriptInstance_EntityId",
                table: "ScriptInstances",
                newName: "IX_ScriptInstances_EntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScriptInstances",
                table: "ScriptInstances",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptInstances_Entity_EntityId",
                table: "ScriptInstances",
                column: "EntityId",
                principalTable: "Entity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptInstances_Room_RoomId",
                table: "ScriptInstances",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScriptInstances_Entity_EntityId",
                table: "ScriptInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_ScriptInstances_Room_RoomId",
                table: "ScriptInstances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScriptInstances",
                table: "ScriptInstances");

            migrationBuilder.RenameTable(
                name: "ScriptInstances",
                newName: "ScriptInstance");

            migrationBuilder.RenameIndex(
                name: "IX_ScriptInstances_RoomId",
                table: "ScriptInstance",
                newName: "IX_ScriptInstance_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_ScriptInstances_EntityId",
                table: "ScriptInstance",
                newName: "IX_ScriptInstance_EntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScriptInstance",
                table: "ScriptInstance",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptInstance_Entity_EntityId",
                table: "ScriptInstance",
                column: "EntityId",
                principalTable: "Entity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptInstance_Room_RoomId",
                table: "ScriptInstance",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id");
        }
    }
}
