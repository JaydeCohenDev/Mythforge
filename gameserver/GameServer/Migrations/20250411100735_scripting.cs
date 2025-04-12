using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameServer.Migrations
{
    /// <inheritdoc />
    public partial class scripting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Scripts",
                table: "Entity");

            migrationBuilder.CreateTable(
                name: "Scripts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AuthorAccountId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scripts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScriptInstance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ScriptFileId = table.Column<int>(type: "INTEGER", nullable: false),
                    EntityId = table.Column<Guid>(type: "TEXT", nullable: true),
                    RoomId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScriptInstance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScriptInstance_Entity_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScriptInstance_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScriptInstance_Scripts_ScriptFileId",
                        column: x => x.ScriptFileId,
                        principalTable: "Scripts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScriptInstance_EntityId",
                table: "ScriptInstance",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ScriptInstance_RoomId",
                table: "ScriptInstance",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ScriptInstance_ScriptFileId",
                table: "ScriptInstance",
                column: "ScriptFileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScriptInstance");

            migrationBuilder.DropTable(
                name: "Scripts");

            migrationBuilder.AddColumn<string>(
                name: "Scripts",
                table: "Entity",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
