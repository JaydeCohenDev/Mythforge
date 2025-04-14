using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameServer.Migrations
{
    /// <inheritdoc />
    public partial class dbsets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Room_CurrentRoomId",
                table: "Entity");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Entity_Id",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Room_LoginRoomId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_Regions_RegionId",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomLink_Room_ExitsId",
                table: "RoomLink");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomLink_Room_RoomId",
                table: "RoomLink");

            migrationBuilder.DropForeignKey(
                name: "FK_ScriptInstances_Entity_EntityId",
                table: "ScriptInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_ScriptInstances_Room_RoomId",
                table: "ScriptInstances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entity",
                table: "Entity");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "Entity",
                newName: "Entities");

            migrationBuilder.RenameIndex(
                name: "IX_Room_RegionId",
                table: "Rooms",
                newName: "IX_Rooms_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Entity_CurrentRoomId",
                table: "Entities",
                newName: "IX_Entities_CurrentRoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entities",
                table: "Entities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entities_Rooms_CurrentRoomId",
                table: "Entities",
                column: "CurrentRoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Entities_Id",
                table: "Players",
                column: "Id",
                principalTable: "Entities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Rooms_LoginRoomId",
                table: "Players",
                column: "LoginRoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomLink_Rooms_ExitsId",
                table: "RoomLink",
                column: "ExitsId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomLink_Rooms_RoomId",
                table: "RoomLink",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Regions_RegionId",
                table: "Rooms",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptInstances_Entities_EntityId",
                table: "ScriptInstances",
                column: "EntityId",
                principalTable: "Entities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptInstances_Rooms_RoomId",
                table: "ScriptInstances",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entities_Rooms_CurrentRoomId",
                table: "Entities");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Entities_Id",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Rooms_LoginRoomId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomLink_Rooms_ExitsId",
                table: "RoomLink");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomLink_Rooms_RoomId",
                table: "RoomLink");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Regions_RegionId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_ScriptInstances_Entities_EntityId",
                table: "ScriptInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_ScriptInstances_Rooms_RoomId",
                table: "ScriptInstances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entities",
                table: "Entities");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameTable(
                name: "Entities",
                newName: "Entity");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_RegionId",
                table: "Room",
                newName: "IX_Room_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Entities_CurrentRoomId",
                table: "Entity",
                newName: "IX_Entity_CurrentRoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entity",
                table: "Entity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Room_CurrentRoomId",
                table: "Entity",
                column: "CurrentRoomId",
                principalTable: "Room",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Entity_Id",
                table: "Players",
                column: "Id",
                principalTable: "Entity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Room_LoginRoomId",
                table: "Players",
                column: "LoginRoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Regions_RegionId",
                table: "Room",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomLink_Room_ExitsId",
                table: "RoomLink",
                column: "ExitsId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomLink_Room_RoomId",
                table: "RoomLink",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
