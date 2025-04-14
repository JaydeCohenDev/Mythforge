using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameServer.Migrations
{
    /// <inheritdoc />
    public partial class removed_scriptfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScriptInstance_Scripts_ScriptFileId",
                table: "ScriptInstance");

            migrationBuilder.DropTable(
                name: "Scripts");

            migrationBuilder.DropIndex(
                name: "IX_ScriptInstance_ScriptFileId",
                table: "ScriptInstance");

            migrationBuilder.DropColumn(
                name: "ScriptFileId",
                table: "ScriptInstance");

            migrationBuilder.AddColumn<string>(
                name: "ScriptClassName",
                table: "ScriptInstance",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScriptClassName",
                table: "ScriptInstance");

            migrationBuilder.AddColumn<int>(
                name: "ScriptFileId",
                table: "ScriptInstance",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Scripts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SourceCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scripts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scripts_Accounts_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScriptInstance_ScriptFileId",
                table: "ScriptInstance",
                column: "ScriptFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_AuthorId",
                table: "Scripts",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScriptInstance_Scripts_ScriptFileId",
                table: "ScriptInstance",
                column: "ScriptFileId",
                principalTable: "Scripts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
