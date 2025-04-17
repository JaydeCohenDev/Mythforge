using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameServer.Migrations
{
    /// <inheritdoc />
    public partial class script_serialization_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScriptClassName",
                table: "ScriptInstances");

            migrationBuilder.DropColumn(
                name: "ScriptData1",
                table: "ScriptInstances");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ScriptClassName",
                table: "ScriptInstances",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ScriptData1",
                table: "ScriptInstances",
                type: "TEXT",
                nullable: true);
        }
    }
}
