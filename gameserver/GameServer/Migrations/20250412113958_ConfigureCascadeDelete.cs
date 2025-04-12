using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameServer.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScriptInstance_Entity_EntityId",
                table: "ScriptInstance");

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptInstance_Entity_EntityId",
                table: "ScriptInstance",
                column: "EntityId",
                principalTable: "Entity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScriptInstance_Entity_EntityId",
                table: "ScriptInstance");

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptInstance_Entity_EntityId",
                table: "ScriptInstance",
                column: "EntityId",
                principalTable: "Entity",
                principalColumn: "Id");
        }
    }
}
